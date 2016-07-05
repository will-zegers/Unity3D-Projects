using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {


	private MusicManager musicManager;

	// Use this for initialization
	void Start () {
		musicManager = FindObjectOfType<MusicManager> ();
		if (musicManager) {
			musicManager.GetComponent<AudioSource>().volume = PlayerPrefsManager.GetMasterVolume();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
