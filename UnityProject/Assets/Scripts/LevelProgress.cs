using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgress : MonoBehaviour {

	public float levelTime;
	public float startDelay;
	public float speedInc;
	public float speedDec;
	public AudioSource audioSource;
	public Text stageNumber, maxStageNumber;
	public AudioClip stageSound;
	public LevelBar[] bars;

	float nextLevel;
	int pos = 0;
	int stage = 0;
	int maxStage = 0;

	void Start() {
		nextLevel = startDelay;
		DeactivateAllBars();
		stageNumber.text = stage.ToString();
		maxStageNumber.text = maxStage.ToString();
	}

	void OnEnable() {
		GameEvents.OnShipKilled += OnShipKilled;
	}

	void OnDisable() {
		GameEvents.OnShipKilled -= OnShipKilled;
	}

	void Update() {
		if ( Time.timeScale > 0.0f ) {
			nextLevel -= Time.deltaTime;
			if ( nextLevel <= 0.0f ) {
				nextLevel += levelTime;
				if ( pos < bars.Length ) {
					AdvanceLevel();
				} else {
					AdvanceStage();
				}
			}
			Time.timeScale += speedInc * Time.unscaledDeltaTime;
		}
	}

	void AdvanceLevel() {
		bars[pos++].Activate();
	}

	void AdvanceStage() {
		DeactivateAllBars();
		audioSource.PlayOneShot(stageSound);
		stageNumber.text = (++stage).ToString();
		if ( stage > maxStage ) {
			maxStage = stage;
			maxStageNumber.text = maxStage.ToString();
		}
		if ( Time.timeScale > 0.0f ) {
			Time.timeScale -= speedDec * Time.unscaledDeltaTime;
			if ( Time.timeScale < 1.0f ) Time.timeScale = 1.0f;
		}
	}

	void DeactivateAllBars() {
		pos = 0;
		for ( int i = 0; i < bars.Length; i++ ) {
			bars[i].Deactivate();
		}
	}

	void OnShipKilled() {
		DeactivateAllBars();
		stage = 0;
		stageNumber.text = stage.ToString();
	}

}
