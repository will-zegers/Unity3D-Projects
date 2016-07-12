using UnityEngine;
using System.Collections;

public class StopButton : MonoBehaviour {

	private void OnMouseDown() {
		GameObject.FindObjectOfType<LevelManager> ().LoadLevel ("01a Start");
	}
}
