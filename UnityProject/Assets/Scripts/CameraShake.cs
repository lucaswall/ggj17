using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	public float amplitude;
	public float shakeTime;
	public float pauseTime;

	float shakeTimeout, pauseTimeout;
	Vector3 originalPosition;

	public void Shake() {
		shakeTimeout = shakeTime;
		pauseTimeout = pauseTime;
		Time.timeScale = 0.0f;
	}

	void Start() {
		originalPosition = transform.position;
	}

	void Update() {
		if ( shakeTimeout > 0.0f ) {
			transform.position = originalPosition + Random.insideUnitSphere * amplitude;
			shakeTimeout -= Time.unscaledDeltaTime;
			if ( shakeTimeout <= 0.0f ) {
				shakeTimeout = 0.0f;
				transform.position = originalPosition;
				GameEvents.ShipKilled();
			}
		}
		if ( pauseTimeout > 0.0f ) {
			pauseTimeout -= Time.unscaledDeltaTime;
			if ( pauseTimeout <= 0.0f ) {
				pauseTimeout = 0.0f;
				Time.timeScale = 1.0f;
			}
		}
	}

}
