using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

	public Renderer render;
	public int waveId;
	public bool mineEnabled = true;
	public MineSpawner spawner;

	public void DisableMine() {
		render.material.color = Color.green;
		mineEnabled = false;
	}

	public void EnableMine() {
		render.material.color = Color.red;
		mineEnabled = true;
	}

	public void DestroyMine() {
		spawner.ReturnMineToPool(transform);
	}

}
