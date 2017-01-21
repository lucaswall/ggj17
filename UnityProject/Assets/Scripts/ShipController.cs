using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour {

	public float deadZone;
	public float moveStep;
	public float limitHorizontalLeft, limitHorizontalRight;
	public float limitVerticalMin, limitVerticalMax;
	public Transform bulletPrefab;
	public Transform bulletPivot;
	public float shootFreq;
	public AudioSource audioSource;
	public AudioClip soundShoot;

	float limitHorizontalMin, limitHorizontalMax;
	float nextShoot = 0.0f;

	Vector3 resetPosition;

	void Start() {
		resetPosition = transform.position;
		float z = - Camera.main.transform.position.z;
		limitHorizontalMin = Camera.main.ViewportToWorldPoint(new Vector3(limitHorizontalLeft, 0.0f, z)).x;
		limitHorizontalMax = Camera.main.ViewportToWorldPoint(new Vector3(limitHorizontalRight, 0.0f, z)).x;
		transform.position = new Vector3(limitHorizontalMin, 0.0f, 0.0f);
	}

	void Update() {
		CheckForMove();
		CheckForLimits();
		CheckForShoot();
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
		if ( pos.y > limitVerticalMax ) pos.y = limitVerticalMax;
		if ( pos.y < limitVerticalMin ) pos.y = limitVerticalMin;
		if ( pos.x > limitHorizontalMax ) pos.x = limitHorizontalMax;
		if ( pos.x < limitHorizontalMin ) pos.x = limitHorizontalMin;
		transform.position = pos;
	}

	public void ResetPosition() {
		transform.position = resetPosition;
		gameObject.SetActive(true);
		enabled = true;
	}

	void CheckForShoot() {
		if ( Input.GetButton("Fire") ) {
			nextShoot -= Time.unscaledDeltaTime;
			if ( nextShoot <= 0.0f ) {
				nextShoot = shootFreq;
				SpawnBullet();
			}
		}
	}

	void SpawnBullet() {
		audioSource.PlayOneShot(soundShoot);
		Transform bullet = Instantiate<Transform>(bulletPrefab);
		bullet.position = bulletPivot.position;
	}

}
