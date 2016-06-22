using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

	public float health = 1.5f;
	public GameObject projectile;
	public float projectileSpeed = -5.0f;
	public float fireProbability = 0.1f;
	public int points = 150;

	public AudioClip fireSound;
	public AudioClip deathSound;

	public ScoreKeeper scoreKeeper;

	public GameObject death;
	
	void OnTriggerEnter2D(Collider2D collider) {

		Projectile projectile = collider.GetComponent<Projectile> ();
		if (projectile) {
			projectile.Hit();
			health -= projectile.GetDamage();
			if (health <= 0) {
				GameObject explosion = Instantiate(death, transform.position, Quaternion.identity) as GameObject;
				AudioSource.PlayClipAtPoint(deathSound, transform.position);
				GameObject.Find ("PlayerScore").GetComponent<ScoreKeeper>().Score (points);
				Destroy(gameObject);
			}
		}
	}

	void Fire() {
		if ((Random.value) <= fireProbability*Time.deltaTime) {
			GameObject beam = Instantiate (projectile, new Vector3 (this.transform.position.x, this.transform.position.y - 0.5f), Quaternion.identity) as GameObject;
			beam.rigidbody2D.velocity = new Vector3 (0, projectileSpeed, 0);
			AudioSource.PlayClipAtPoint(fireSound, transform.position);
		}
	}

	void Update() {
		Fire ();
	}
}
