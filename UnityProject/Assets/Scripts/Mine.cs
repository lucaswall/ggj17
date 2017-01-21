using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

	public Renderer render;
	public int waveId;
	public bool mineEnabled = true;

	public void DisableMine() {
		render.material.color = Color.green;
		mineEnabled = false;
	}

}
