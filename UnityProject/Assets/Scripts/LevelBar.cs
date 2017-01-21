using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBar : MonoBehaviour {

	public AudioSource audioSource;
	public AudioClip soundActivate;
	public Color colorActive;
	public Color colorInactive;

	Image image;

	void Awake() {
		image = GetComponent<Image>();
	}

	public void Activate() {
		image.color = colorActive;
		audioSource.PlayOneShot(soundActivate);
	}

	public void Deactivate() {
		image.color = colorInactive;
	}

}
