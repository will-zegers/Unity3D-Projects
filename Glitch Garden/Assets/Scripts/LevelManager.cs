using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	public float autoLoadNextLevelAfter = 0;

	public void Start() {
		if (autoLoadNextLevelAfter > 0) {
			Invoke ("LoadNextLevel", autoLoadNextLevelAfter);
		} else if (autoLoadNextLevelAfter < 0) {
			Debug.LogError("Level auot load disabled, use a positive number");
		}
	}

	public void LoadLevel(string name) {
		Application.LoadLevel (name);
	}

	public void LoadNextLevel() {
		Application.LoadLevel (Application.loadedLevel+1);
	}

	public void QuitRequest() {
		Application.Quit ();
	}
}
