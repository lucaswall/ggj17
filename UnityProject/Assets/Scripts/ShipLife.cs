using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipLife : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Mine mine = other.GetComponent<Mine>();
		if ( mine != null ) {
			if ( mine.mineEnabled ) {
				GameEvents.ShipKilled();
			} else {
				mine.DestroyMine();
			}
		}
	}

}
