using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineExplosion : MonoBehaviour {

	void Start() {
		Destroy(gameObject, 0.5f);
	}

	void OnTriggerEnter(Collider other) {
		Mine mine = other.GetComponent<Mine>();
		if ( mine != null && ! mine.mineEnabled ) {
			mine.KillMine();
		}
	}

}
