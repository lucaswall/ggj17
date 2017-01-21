using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMovement : MonoBehaviour {

	public float speed;
	public float killPosition;

	void Update() {
		Vector3 pos = transform.position;
		pos.x += speed * Time.deltaTime;
		transform.position = pos;
		if ( pos.x < killPosition ) {
			Destroy(gameObject);
		}
	}

}
