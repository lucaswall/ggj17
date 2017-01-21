using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	public float deadZone;
	public float moveStep;
	public float limitVertical;
	public float limitHorizontalMin, limitHorizontalMax;

	Vector3 resetPosition;

	void Start() {
		resetPosition = transform.position;
	}

	void OnEnable() {
		GameEvents.OnShipKilled += OnShipKilled;
	}

	void OnDisable() {
		GameEvents.OnShipKilled -= OnShipKilled;
	}

	void Update() {
		CheckForMove();
		CheckForLimits();
	}

	void CheckForMove() {
		float h = Input.GetAxis("Vertical");
		float v = Input.GetAxis("Horizontal");
		Vector3 pos = transform.position;
		if ( Mathf.Abs(h) > deadZone ) {
			pos.y += Mathf.Sign(h) * moveStep * Time.unscaledDeltaTime;
		}
		if ( Mathf.Abs(v) > deadZone ) {
			pos.x += Mathf.Sign(v) * moveStep * Time.unscaledDeltaTime;
		}
		transform.position = pos;
	}

	void CheckForLimits() {
		Vector3 pos = transform.position;
		if ( pos.y > limitVertical ) pos.y = limitVertical;
		if ( pos.y < -limitVertical ) pos.y = -limitVertical;
		if ( pos.x > limitHorizontalMax ) pos.x = limitHorizontalMax;
		if ( pos.x < limitHorizontalMin ) pos.x = limitHorizontalMin;
		transform.position = pos;
	}

	void OnShipKilled() {
		transform.position = resetPosition;
	}

}
