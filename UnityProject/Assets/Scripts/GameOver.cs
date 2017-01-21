using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public LevelProgress levelProgress;
	public Text scoreField;

	void Start() {
		GameEvents.OnGameOver += OnGameOver;
		gameObject.SetActive(false);
	}

	void OnDestroy() {
		GameEvents.OnGameOver -= OnGameOver;
	}

	void OnGameOver() {
		scoreField.text = String.Format("YOUR SCORE IS {0}", levelProgress.CurrentStage);
		gameObject.SetActive(true);
	}

	void Update() {
		if ( Input.GetButtonDown("Start") ) {
			//GameEvents.RestartGame();
			SceneManager.LoadScene("MainMenu");
			gameObject.SetActive(false);
		}
	}

}
