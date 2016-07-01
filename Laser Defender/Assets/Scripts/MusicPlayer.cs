using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	public AudioClip bgMusic;

	private AudioSource audioSource;

	void Awake() {
		if (instance != null && instance != this) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
			audioSource = GetComponent<AudioSource>();
			audioSource.clip = bgMusic;
			audioSource.loop = true;
			audioSource.Play();
		}
	}
}
