using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	static MusicPlayer instance = null;

	public AudioClip startClip, gameClip, endClip;

	private AudioSource audioSource;

	void Awake() {
		if (instance != null && instance != this) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
			audioSource = GetComponent<AudioSource>();
			OnLevelWasLoaded(0);
		}
	}

	void OnLevelWasLoaded(int level) {
		Debug.Log ("MusicPlayer: loaded level" + level);
		audioSource.Stop ();

		switch (level) {
		case 0:
			audioSource.clip = startClip;
			break;
		case 1:
			audioSource.clip = gameClip;
			break;
		default:
			audioSource.clip = endClip;
			break;
		}
		audioSource.loop = true;
		audioSource.Play ();
	}
}
