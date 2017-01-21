using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineGroup : MonoBehaviour {

	public float affectDistanceSq;
	public float checkThresholdPosition;
	public float checkInterval;

	float nextCheck;

	void Update() {
		nextCheck -= Time.deltaTime;
		if ( nextCheck <= 0.0f ) {
			nextCheck += checkInterval;
			CheckAllMines();
		}
	}

	void OnEnable() {
		GameEvents.OnShipKilled += DestroyAllMines;
		GameEvents.OnRestartGame += DestroyAllMines;
	}

	void OnDisable() {
		GameEvents.OnShipKilled -= DestroyAllMines;
		GameEvents.OnRestartGame -= DestroyAllMines;
	}

	void CheckAllMines() {
		GameObject[] mines = GameObject.FindGameObjectsWithTag("Mine");
		DisableNearMines(mines);
	}

	void DisableNearMines(GameObject[] mines) {
		for ( int i = 0; i < mines.Length; i++ ) {
			if ( mines[i].transform.position.x < checkThresholdPosition ) continue;
			Mine mine1 = mines[i].GetComponent<Mine>();
			for ( int j = i + 1; j < mines.Length; j++ ) {
				if ( mines[j].transform.position.x < checkThresholdPosition ) continue;
				Vector3 dist = mines[i].transform.position - mines[j].transform.position;
				if ( dist.sqrMagnitude <= affectDistanceSq ) {
					Mine mine2 = mines[j].GetComponent<Mine>();
					if ( mine1.waveId != mine2.waveId ) {
						mine1.DisableMine();
						mine2.DisableMine();
					}
				}
			}
		}
	}

	void DestroyAllMines() {
		GameObject[] mines = GameObject.FindGameObjectsWithTag("Mine");
		for ( int i = 0; i < mines.Length; i++ ) {
			mines[i].GetComponent<Mine>().DestroyMine();
		}
		nextCheck = checkInterval;
	}

}
