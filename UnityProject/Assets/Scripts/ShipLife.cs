using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLife : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip soundDeath;
	public AudioClip[] soundGather;

	CameraShake cameraShake;
	ShipController shipController;

	void Awake() {
		cameraShake = FindObjectOfType<CameraShake>();
		shipController = GetComponent<ShipController>();
	}

	void OnEnable() {
		GameEvents.OnShipKilled += OnShipKilled;
	}

	void OnDisable() {
		GameEvents.OnShipKilled -= OnShipKilled;
	}

	void OnTriggerEnter(Collider other) {
		Mine mine = other.GetComponent<Mine>();
		if ( mine != null ) {
			if ( mine.mineEnabled ) {
				audioSource.PlayOneShot(soundDeath);
				cameraShake.Shake();
				shipController.enabled = false;
			} else {
				/*if ( ! audioSource.isPlaying ) {
					audioSource.PlayOneShot(soundGather[Random.Range(0, soundGather.Length)]);
				}
				mine.DestroyMine();*/
			}
		}
	}

	void OnShipKilled() {
		shipController.enabled = true;
		shipController.ResetPosition();
	}

}
