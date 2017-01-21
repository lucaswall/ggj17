using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

	public MonoBehaviour startText;
	public float blinkSpeed;

	float nextBlink = 0.0f;

	void Start() {
		nextBlink = blinkSpeed;
	}

	void Update() {
		BlinkText();
		CheckForStartButton();
	}

	void CheckForStartButton() {
		if ( Input.GetButtonDown("Start") ) {
			enabled = false;
			SceneManager.LoadScene("Game");
		}
	}

	void BlinkText() {
		nextBlink -= Time.deltaTime;
		if ( nextBlink <= 0.0f ) {
			nextBlink += blinkSpeed;
			startText.enabled = ! startText.enabled;
		}
	}

}
