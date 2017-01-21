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

}
