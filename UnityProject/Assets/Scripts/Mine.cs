using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

	public SpriteRenderer render;
	public int waveId;
	public bool mineEnabled = true;
	public MineSpawner spawner;

	public void DisableMine() {
		render.color = Color.green;
		mineEnabled = false;
	}

	public void EnableMine() {
		render.color = Color.red;
		mineEnabled = true;
	}

	public void DestroyMine() {
		spawner.ReturnMineToPool(transform);
	}

}
