using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour {

	public SpriteRenderer render;
	public int waveId;
	public bool mineEnabled = true;
	public MineSpawner spawner;
	public Color colorEnabled;
	public Color colorDisabled;
	public float affectDistanceSq;
	public float checkThresholdPosition;
	public int initialLife;
	public Transform explosionPrefab;
	public AudioSource audioSource;
	public AudioClip soundDestroy;
	public ParticleSystem particlesExplode;
	public bool startEnabled;
	public Collider mineCollider;
	public float protectTime;

	int life;
	bool dead = false;
	float protect;

	void Awake() {
		life = initialLife;
		if ( startEnabled ) EnableMine();
		else DisableMine();
	}

	void Update() {
		if ( protect > 0.0f ) {
			protect -= Time.unscaledDeltaTime;
			if ( protect < 0.0f ) {
				protect = 0.0f;
			}
		}
	}

	public void DisableMine() {
		render.color = colorDisabled;
		mineEnabled = false;
	}

	public void EnableMine() {
		render.color = colorEnabled;
		mineEnabled = true;
	}

	public void DestroyMine() {
		if ( spawner != null ) {
			mineCollider.enabled = false;
			spawner.ReturnMineToPool(transform);
		} else {
			Destroy(gameObject);
		}
	}

	public void ResetMine() {
		life = initialLife;
		dead = false;
		render.enabled = true;
		mineCollider.enabled = true;
		EnableMine();
		protect = protectTime;
	}

	public void CheckForNearMines() {
		GameObject[] mines = GameObject.FindGameObjectsWithTag("Mine");
		for ( int j = 0; j < mines.Length; j++ ) {
			Vector3 pos = mines[j].transform.position;
			if ( pos.x < checkThresholdPosition ) continue;
			Vector3 dist = transform.position - pos;
			if ( dist.sqrMagnitude <= affectDistanceSq ) {
				Mine mine2 = mines[j].GetComponent<Mine>();
				if ( waveId != mine2.waveId ) {
					DisableMine();
					return;
				}
			}
		}
	}

	public void Hit() {
		if ( --life <= 0.0f ) {
			KillMine();
		}
	}

	public void KillMine() {
		if ( dead || protect > 0.0f ) return;
		dead = true;
		StartCoroutine(DoDestroy());
	}

	IEnumerator DoDestroy() {
		if ( audioSource != null && ! audioSource.isPlaying ) {
			audioSource.PlayOneShot(soundDestroy);
		}
		render.enabled = false;
		mineCollider.enabled = false;
		particlesExplode.Play();
		float oldScale = Time.timeScale;
		Time.timeScale = 0.0f;
		yield return null;
		if ( oldScale > 0.0f ) {
			Time.timeScale = oldScale;
		}
		Transform explosion = Instantiate<Transform>(explosionPrefab);
		explosion.position = transform.position;
		while ( particlesExplode.isPlaying ) yield return null;
		DestroyMine();
	}

}
