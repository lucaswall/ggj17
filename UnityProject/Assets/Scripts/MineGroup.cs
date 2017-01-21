using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineGroup : MonoBehaviour {

	void OnEnable() {
		GameEvents.OnShipKilled += DestroyAllMines;
		GameEvents.OnRestartGame += DestroyAllMines;
	}

	void OnDisable() {
		GameEvents.OnShipKilled -= DestroyAllMines;
		GameEvents.OnRestartGame -= DestroyAllMines;
	}

	void DestroyAllMines() {
		GameObject[] mines = GameObject.FindGameObjectsWithTag("Mine");
		for ( int i = 0; i < mines.Length; i++ ) {
			mines[i].GetComponent<Mine>().DestroyMine();
		}
	}

}
