using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineGroup : MonoBehaviour {

	public float affectDistanceSq;

	void Update() {
		CheckAllMines();
	}

	void OnEnable() {
		GameEvents.OnShipKilled += DestroyAllMines;
	}

	void OnDisable() {
		GameEvents.OnShipKilled -= DestroyAllMines;
	}

	void CheckAllMines() {
		GameObject[] mines = GameObject.FindGameObjectsWithTag("Mine");
		DisableNearMines(mines);
	}

	void DisableNearMines(GameObject[] mines) {
		for ( int i = 0; i < mines.Length; i++ ) {
			Mine mine1 = mines[i].GetComponent<Mine>();
			for ( int j = i + 1; j < mines.Length; j++ ) {
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
			Destroy(mines[i].gameObject);
		}
	}

}
