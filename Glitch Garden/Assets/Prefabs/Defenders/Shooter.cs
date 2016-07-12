using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	public GameObject gun;

	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	private void Start() {		
		animator = GameObject.FindObjectOfType<Animator> ();

		// Creates a parent if necessary
		projectileParent = GameObject.Find ("Projectiles");
		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}

		SetMyLaneSpawner ();
	}

	private void Update() {
		if (IsAttackerAheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}


	private void SetMyLaneSpawner() {
		Spawner[] spawners = GameObject.FindObjectsOfType<Spawner> ();
		foreach (Spawner spawner in spawners) {
			if (spawner.transform.position.y == this.transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}
		}
		Debug.LogError (name + " can't find spawner in lane!");
	}

	private bool IsAttackerAheadInLane() {

		// Check for children (if any exist) that are in front of the defender
		foreach (Transform child in myLaneSpawner.transform) {
			if (child.position.x > this.transform.position.x) {
				return true;
			}
		}

		return false;
	}

	private void FireGun() {
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
}
