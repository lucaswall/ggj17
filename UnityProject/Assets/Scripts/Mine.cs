using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

	public SpriteRenderer render;
	public int waveId;
	public bool mineEnabled = true;
	public MineSpawner spawner;
	public Color colorEnabled;
	public Color colorDisabled;
	public float affectDistanceSq;
	public float checkThresholdPosition;

	public void DisableMine() {
		render.color = colorDisabled;
		mineEnabled = false;
	}

	public void EnableMine() {
		render.color = colorEnabled;
		mineEnabled = true;
	}

	public void DestroyMine() {
		spawner.ReturnMineToPool(transform);
	}

	public void CheckForNearMines() {
		GameObject[] mines = GameObject.FindGameObjectsWithTag("Mine");
		for ( int j = 0; j < mines.Length; j++ ) {
			Vector3 pos = mines[j].transform.position;
			if ( pos.x < checkThresholdPosition ) continue;
			Vector3 dist = transform.position - pos;
			if ( dist.sqrMagnitude <= affectDistanceSq ) {
				Mine mine2 = mines[j].GetComponent<Mine>();
				if ( waveId != mine2.waveId ) {
					DisableMine();
					return;
				}
			}
		}
	}

}
