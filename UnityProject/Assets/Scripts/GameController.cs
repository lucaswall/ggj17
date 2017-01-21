using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public float speedInc;

	void Update() {
		if ( Time.timeScale > 0.0f ) {
			Time.timeScale += speedInc * Time.unscaledDeltaTime;
		}
	}

}
