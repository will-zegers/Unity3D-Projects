using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	private void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	private void OnTriggerEnter2D(Collider2D collider) {
		if (collider.GetComponent<Attacker> ()) {
			levelManager.LoadLevel ("03b Lose");
		}
	}
}
