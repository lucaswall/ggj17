using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendShipLife : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip soundExplode;
	public AudioClip soundShoot;
	public SpriteRenderer render;
	public Collider shipCollider;
	public Transform bulletPrefab;
	public Transform bulletPivot;
	public float shootFreq;
	public float initialWait;
	public int shootCount;
	public ParticleSystem killParticles;

	void Start() {
		StartCoroutine(RunTutorial());
	}

	void OnTriggerEnter(Collider other) {
		Mine mine = other.GetComponent<Mine>();
		if ( mine != null ) {
			audioSource.PlayOneShot(soundExplode);
			render.enabled = false;
			shipCollider.enabled = false;
			killParticles.Play();
			Destroy(gameObject, 2.0f);
		}
	}

	void SpawnBullet() {
		audioSource.PlayOneShot(soundShoot);
		Transform bullet = Instantiate<Transform>(bulletPrefab);
		bullet.position = bulletPivot.position;
	}

	IEnumerator RunTutorial() {
		yield return new WaitForSeconds(initialWait);
		for ( int i = 0; i < shootCount; i++ ) {
			SpawnBullet();
			yield return new WaitForSeconds(shootFreq);
		}
	}

}
