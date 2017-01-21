using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesHolder : MonoBehaviour {

	public Image[] livesImgs;

	public bool NoMoreLives { get { return pos < 0; } }

	int pos;

	void Start() {
		pos = livesImgs.Length - 1;
	}

	void OnEnable() {
		GameEvents.OnShipKilled += OnShipKilled;
		GameEvents.OnRestartGame += OnRestartGame;
	}

	void OnDisable() {
		GameEvents.OnShipKilled -= OnShipKilled;
		GameEvents.OnRestartGame -= OnRestartGame;
	}

	void ConsumeLife() {
		livesImgs[pos--].gameObject.SetActive(false);
		if ( pos < 0 ) GameEvents.GameOver();
	}

	void OnShipKilled() {
		if ( pos >= 0 ) {
			ConsumeLife();
		}
	}

	void OnRestartGame() {
		for ( int i = 0; i < livesImgs.Length; i++ ) {
			livesImgs[i].gameObject.SetActive(true);
		}
		pos = livesImgs.Length - 1;
	}

}
