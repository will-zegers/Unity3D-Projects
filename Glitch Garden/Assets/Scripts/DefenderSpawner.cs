using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	private GameObject defenderParent;
	private StarDisplay starDisplay;

	private void Start() {
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
		
		defenderParent = GameObject.Find ("Defenders");
		if (!defenderParent) {
			defenderParent = new GameObject("Defenders");
		}
	}

	private void OnMouseDown() {

		GameObject defender = Button.selectedDefender;
		int defenderCost = defender.GetComponent<Defender> ().starCost;

		StarDisplay.Status result = starDisplay.UseStars (defenderCost);
		if (result == StarDisplay.Status.FAILURE) {
			Debug.Log ("Insufficient Stars");
			return;
		}

		Vector2 defenderPosition = SnapToGrid ();
		SpawnDefender (defenderPosition, defender);
	}

	private void SpawnDefender(Vector2 position, GameObject defender) {
		
		GameObject newDefender = Instantiate (
			defender,
			position,
			Quaternion.identity) as GameObject;
		newDefender.transform.parent = defenderParent.transform;

	}

	private Vector2 SnapToGrid() {
		Vector2 rawWorldPos = CalculateWorldPointOfMouseClick ();
		return new Vector2 (Mathf.Round (rawWorldPos.x), Mathf.Round (rawWorldPos.y));
	}

	private Vector2 CalculateWorldPointOfMouseClick() {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		return new Vector2(mousePosition.x, mousePosition.y);
	}
}
