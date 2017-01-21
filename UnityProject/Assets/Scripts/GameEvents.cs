using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour {

	public static event ShipKilledAction OnShipKilled;
	public static event GameOverAction OnGameOver;

	public delegate void ShipKilledAction();
	public delegate void GameOverAction();

	public static void ShipKilled() {
		if ( OnShipKilled != null ) OnShipKilled();
	}

	public static void GameOver() {
		if ( OnGameOver != null ) OnGameOver();
	}

}
