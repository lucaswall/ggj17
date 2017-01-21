using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour {

	public float interval;
	public int waveId;
	public int initialMineCount;

	public Transform minePrefab;

	float nextSpawn;
	Queue<Transform> mines = new Queue<Transform>();

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

	void FillMineCache() {
		for ( int i = 0; i < initialMineCount; i++ ) {
			ReturnMineToPool(NewMine());
		}
	}

	void SpawnMine() {
		Transform mine;
		if ( mines.Count > 0 ) {
			mine = mines.Dequeue();
		} else {
			mine = NewMine();
		}
		mine.position = transform.position;
		mine.GetComponent<Mine>().EnableMine();
		mine.gameObject.SetActive(true);
	}

	public void ReturnMineToPool(Transform mine) {
		mine.gameObject.SetActive(false);
		mines.Enqueue(mine);
	}

	Transform NewMine() {
		Transform mine = Instantiate<Transform>(minePrefab);
		Mine mineRef = mine.GetComponent<Mine>();
		mineRef.waveId = waveId;
		mineRef.spawner = this;
		return mine;
	}

}
