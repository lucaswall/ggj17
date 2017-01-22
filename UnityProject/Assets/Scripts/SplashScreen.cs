using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

	public Image splashImg;
	public Image blackCurtain;

	public float initialWaitTime;
	public float fadeInTime;
	public float zoomInSpeed;
	public float totalSplashTime;
	public string sceneName;

	void Start() {
		StartCoroutine(FadeIn());
		StartCoroutine(ZoomIn());
		StartCoroutine(NextScene());
	}

	IEnumerator FadeIn() {
		float t = 0.0f;
		Color c = Color.black;
		yield return new WaitForSeconds(initialWaitTime);
		while ( t <= 1.0f ) {
			t += Time.deltaTime / fadeInTime;
			c.a = Mathf.Lerp(1.0f, 0.0f, t);
			blackCurtain.color = c;
			yield return null;
		}
		blackCurtain.gameObject.SetActive(false);
	}

	IEnumerator ZoomIn() {
		yield return new WaitForSeconds(initialWaitTime);
		Vector3 scale = Vector3.one;
		for ( ;; ) {
			scale.x += zoomInSpeed * Time.deltaTime;
			scale.y = scale.z = scale.x;
			splashImg.transform.localScale = scale;
			yield return null;
		}
	}

	IEnumerator NextScene() {
		yield return new WaitForSeconds(totalSplashTime);
		SceneManager.LoadScene(sceneName);
	}

}
