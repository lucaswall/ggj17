using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBullet : MonoBehaviour {

	public Vector3 speed;
	public float maxPosition;
	public Animator animator;

	bool frozen = false;

	void Update() {
		if ( ! frozen ) {
			transform.Translate(speed * Time.deltaTime);
			if ( transform.position.x > maxPosition ) {
				Destroy(gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider other) {
		Mine mine = other.GetComponent<Mine>();
		if ( mine != null ) {
			frozen = true;
			GetComponent<Collider>().enabled = false;
			animator.SetTrigger("destroy");
			Destroy(gameObject, 2.0f);
			if ( ! mine.mineEnabled ) {
				Debug.Log("hey!!");
				mine.Hit();
			}
		}
	}

}
