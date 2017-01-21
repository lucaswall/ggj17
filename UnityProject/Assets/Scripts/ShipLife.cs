using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLife : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip soundDeath;
	public AudioClip[] soundGather;
	public LivesHolder livesHolder;

	CameraShake cameraShake;
	ShipController shipController;

	void Awake() {
		cameraShake = FindObjectOfType<CameraShake>();
		shipController = GetComponent<ShipController>();
	}

	void Start() {
		GameEvents.OnShipKilled += OnShipKilled;
		GameEvents.OnRestartGame += OnRestartGame;
	}

	void OnDestroy() {
		GameEvents.OnShipKilled -= OnShipKilled;
		GameEvents.OnRestartGame -= OnRestartGame;
	}

	void OnTriggerEnter(Collider other) {
		Mine mine = other.GetComponent<Mine>();
		if ( mine != null ) {
			if ( mine.mineEnabled ) {
				KillShip();
			}
		}
	}

	void OnShipKilled() {
		if ( livesHolder.NoMoreLives ) {
			gameObject.SetActive(false);
		} else {
			shipController.enabled = true;
			shipController.ResetPosition();
		}
	}

	void KillShip() {
		audioSource.PlayOneShot(soundDeath);
		cameraShake.Shake();
		shipController.enabled = false;
	}

	void OnRestartGame() {
		shipController.ResetPosition();
	}

}
