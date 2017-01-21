using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMovement : MonoBehaviour {

	public float baseLine;
	public float amplitude;
	public float period;

	float angle = 0.0f;

	void Update() {
		angle += ( Mathf.PI * 2 / period ) * Time.deltaTime;
		Vector3 pos = transform.position;
		pos.y = baseLine + Mathf.Sin(angle) * amplitude;
		transform.position = pos;
	}

}
