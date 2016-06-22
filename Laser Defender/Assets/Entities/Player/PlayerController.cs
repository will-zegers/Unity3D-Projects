using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 15.0f;
	public float projectileSpeed = 0f;
	public float firingRate = 0.2f;
	public float padding = 0.5f;
	public float health = 2.5f;
	public GameObject projectile;
	public AudioClip fireSound;
	public GameObject death;

	private float xMin = -5;
	private float xMax = 5;

	// Use this for initialization
	void Start () {
		float cameraDistance = transform.position.z - Camera.main.transform.position.z;
		xMin = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, cameraDistance)).x;
		xMax = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, cameraDistance)).x;
	}

	private void Fire() {
		GameObject beam = Instantiate(projectile, new Vector3(this.transform.position.x, this.transform.position.y+0.66f), Quaternion.identity) as GameObject;
		beam.rigidbody2D.velocity = new Vector3(0,projectileSpeed, 0);
		AudioSource.PlayClipAtPoint (fireSound, transform.position);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > (xMin + padding)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < (xMax - padding)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}

		if (Input.GetKeyDown(KeyCode.Space)) {
			InvokeRepeating("Fire",0.000001f, firingRate);
		} else if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke("Fire");
		}		
	}
	
	void OnTriggerEnter2D(Collider2D collider) {
		
		Projectile projectile = collider.GetComponent<Projectile> ();
		if (projectile) {
			projectile.Hit();
			health -= projectile.GetDamage();
			if (health <= 0) {
				Die ();
			}
		}
	}

	void Die() {
		GameObject.Find ("LevelManager").GetComponent<LevelManager> ().LoadLevel ("Win");
		Destroy(gameObject);
	}
}
