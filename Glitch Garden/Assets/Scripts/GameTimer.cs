using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	private Slider slider;
	private LevelManager levelManager;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	private GameObject winLabel;

	public float levelTimeSeconds = 60f;

	// Use this for initialization
	void Start () {
		slider = GetComponent<Slider> ();
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		audioSource = GetComponent<AudioSource> ();

		winLabel = GameObject.Find ("YouWon");
		if (!winLabel) {
			Debug.LogWarning ("Missing 'You Won' message");
		} else {
			winLabel.SetActive(false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelTimeSeconds;
		if (Time.timeSinceLevelLoad >= levelTimeSeconds && !isEndOfLevel) {
			HandleWinCondition();
		}
	}

	private void HandleWinCondition() {
		audioSource.Play ();
		isEndOfLevel = true;
		GameObject[] toDestroy = GameObject.FindGameObjectsWithTag ("destroyOnWin");
		foreach (GameObject obj in toDestroy) {
			Destroy (obj);
		}
		winLabel.SetActive(true);
		Invoke ("LoadNextLevel", audioSource.clip.length);
	}

	private void LoadNextLevel() {
		levelManager.LoadNextLevel ();
	}
}
