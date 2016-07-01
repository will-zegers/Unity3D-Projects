using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

	public AudioClip[] levelMusicChangeArray;

	private AudioSource audioSource;

	private void Awake() {
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Don't destroy on load: " + name);
	}
	private void Start() {
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnLevelWasLoaded(int level) {
		AudioClip levelTrack = levelMusicChangeArray [level];
		Debug.Log ("Playing clip " + levelTrack);
		if (levelTrack) {
			audioSource.clip = levelMusicChangeArray[level];
			audioSource.loop = true;
			audioSource.Play();
		}
	}

	public void ChangeVolume(float volume) {
		audioSource.volume = volume;
	}
}
