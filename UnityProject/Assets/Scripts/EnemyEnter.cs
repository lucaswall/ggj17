using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEnter : MonoBehaviour {

	public SineMovement sineMovement;
	public MineSpawner mineSpawner;

	void Start() {
		sineMovement.enabled = false;
		mineSpawner.enabled = false;
		StartCoroutine(Intro());
	}

	IEnumerator Intro() {
		float z = - Camera.main.transform.position.z;
		float startX = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, 0.0f, z)).x;
		float endX = Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0.0f, z)).x;
		float y = sineMovement.GetPositionY();
		Vector3 startPos = new Vector3(startX, y, 0.0f);
		Vector3 endPos = new Vector3(endX, y, 0.0f);
		transform.position = startPos;

		yield return new WaitForSeconds(2.0f);

		float t = 0.0f;
		while ( t <= 1.0f ) {
			t += Time.deltaTime;
			transform.position = Vector3.Lerp(startPos, endPos, t);
			yield return null;
		}
		transform.position = endPos;

		sineMovement.enabled = true;
		yield return new WaitForSeconds(1.0f);
		mineSpawner.enabled = true;
	}

}
