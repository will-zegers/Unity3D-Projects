using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed = 1f;
	public float damage = 10f;
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.right * speed * Time.deltaTime);
	}

	private void OnTriggerEnter2D(Collider2D collider) {

		if (!collider.GetComponent<Attacker> ()) {
			return;
		}

		Health targetHealth = collider.GetComponent<Health> ();
		if (targetHealth) {
			targetHealth.DealDamage(damage);
			Destroy (gameObject);
		}
	}
}