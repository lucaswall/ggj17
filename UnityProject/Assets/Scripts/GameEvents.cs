using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour {

	public static event ShipKilledAction OnShipKilled;

	public delegate void ShipKilledAction();

	public static void ShipKilled() {
		if ( OnShipKilled != null ) OnShipKilled();
	}

}
