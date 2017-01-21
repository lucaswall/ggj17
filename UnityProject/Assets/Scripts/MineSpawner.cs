using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour {

	public float interval;
	public int waveId;

	public Transform minePrefab;

	float nextSpawn;

	void Start() {
		nextSpawn = interval;
	}

	void Update() {
		nextSpawn -= Time.deltaTime;
		if ( nextSpawn <= 0.0f ) {
			nextSpawn += interval;
			SpawnMine();
		}
	}

	void SpawnMine() {
		Transform mine = Instantiate<Transform>(minePrefab);
		mine.position = transform.position;
		mine.GetComponent<Mine>().waveId = waveId;
	}

}
