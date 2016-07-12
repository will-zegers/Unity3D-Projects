using UnityEngine;
using System.Collections;

public class Stone : MonoBehaviour {

	private Animator animator;

	private void Start() {
		animator = GetComponent<Animator> ();
	}

	private void OnTriggerStay2D(Collider2D collider) {

		if (collider.GetComponent<Attacker> ()) {
			animator.SetTrigger ("isUnderAttackTrigger");
		}
	}
}
