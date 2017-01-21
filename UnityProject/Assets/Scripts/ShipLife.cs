using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLife : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip soundDeath;
	public AudioClip[] soundGather;

	CameraShake cameraShake;

	void Awake() {
		cameraShake = FindObjectOfType<CameraShake>();
	}

	void OnTriggerEnter(Collider other) {
		Mine mine = other.GetComponent<Mine>();
		if ( mine != null ) {
			if ( mine.mineEnabled ) {
				audioSource.PlayOneShot(soundDeath);
				cameraShake.Shake();
			} else {
				if ( ! audioSource.isPlaying ) {
					audioSource.PlayOneShot(soundGather[Random.Range(0, soundGather.Length)]);
				}
				mine.DestroyMine();
			}
		}
	}

}
