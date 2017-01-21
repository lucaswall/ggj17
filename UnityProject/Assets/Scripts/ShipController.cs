using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	public float deadZone;
	public float moveStep;

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
		float h = Input.GetAxis("Vertical");
		if ( Mathf.Abs(h) > deadZone ) {
			Vector3 pos = transform.position;
			pos.y += Mathf.Sign(h) * moveStep * Time.deltaTime;
			transform.position = pos;
		}
	}

	void OnShipKilled() {
		transform.position = resetPosition;
	}

}
