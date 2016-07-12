using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;

	private Text costText;

	private void Start() {
		costText = transform.FindChild ("Cost").GetComponent<Text> ();
		if (costText) {
			costText.text = defenderPrefab.GetComponent<Defender> ().starCost.ToString ();
		} else {
			Debug.LogWarning ("Could not find text component for " + name);
		}
	}

	private void OnMouseDown() {

		Button[] buttonArray = GameObject.FindObjectsOfType<Button> ();
		foreach (Button button in buttonArray) {
			button.GetComponent<SpriteRenderer> ().color = Color.black;
		}

		GetComponent<SpriteRenderer> ().color = Color.white;
		selectedDefender = defenderPrefab;
	}
}
