using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour {

	public static event ShipKilledAction OnShipKilled;
	public static event GameOverAction OnGameOver;
	public static event RestartGameAction OnRestartGame;

	public delegate void ShipKilledAction();
	public delegate void GameOverAction();
	public delegate void RestartGameAction();

	public static void ShipKilled() {
		if ( OnShipKilled != null ) OnShipKilled();
	}

	public static void GameOver() {
		if ( OnGameOver != null ) OnGameOver();
	}

	public static void RestartGame() {
		if ( OnRestartGame != null ) OnRestartGame();
	}

}
