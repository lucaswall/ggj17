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
	public float stageNumberScale;
	public LevelBar[] bars;
	public LivesHolder livesHolder;

	public int CurrentStage { get { return stage; } }

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
		GameEvents.OnRestartGame += OnRestartGame;
	}

	void OnDisable() {
		GameEvents.OnShipKilled -= OnShipKilled;
		GameEvents.OnRestartGame -= OnRestartGame;
	}

	void Update() {
		if ( livesHolder.NoMoreLives ) return;
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
		StartCoroutine(PulseText(stageNumber.transform));
		if ( stage > maxStage ) {
			maxStage = stage;
			maxStageNumber.text = maxStage.ToString();
		}
		if ( Time.timeScale > 0.0f ) {
			Time.timeScale -= speedDec * Time.unscaledDeltaTime;
			if ( Time.timeScale < 1.0f ) Time.timeScale = 1.0f;
		}
	}

	IEnumerator PulseText(Transform t) {
		float dt = 0.0f;
		while ( dt <= 1.0f ) {
			float s = Mathf.SmoothStep(stageNumberScale, 1.0f, dt);
			t.localScale = new Vector3(s, s, s);
			dt += Time.deltaTime;
			yield return null;
		}
		t.localScale = Vector3.one;
	}

	void DeactivateAllBars() {
		pos = 0;
		for ( int i = 0; i < bars.Length; i++ ) {
			bars[i].Deactivate();
		}
	}

	void OnShipKilled() {
		DeactivateAllBars();
		stageNumber.text = stage.ToString();
	}

	void OnRestartGame() {
		stage = maxStage = 0;
		Time.timeScale = 1.0f;
		nextLevel = startDelay;
		DeactivateAllBars();
		stageNumber.text = stage.ToString();
		maxStageNumber.text = maxStage.ToString();
	}

}
