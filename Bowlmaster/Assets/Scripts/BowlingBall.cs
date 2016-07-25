using UnityEngine;
using System.Collections;

public class BowlingBall : MonoBehaviour {

	public Vector3 launchVelocity = Vector3.zero;
	public bool inPlay = false;

	private Vector3 startPosition;
    private Rigidbody rigidBody;
    private AudioSource audioSource;

	public void Launch (Vector3 velocity)
	{
		rigidBody.useGravity = true;
		rigidBody.velocity = velocity;

		inPlay = true;

		audioSource.Play ();
	}

	public void Reset() {
		rigidBody.velocity        = Vector3.zero;
		rigidBody.angularVelocity = Vector3.zero;
		rigidBody.useGravity      = false;

		transform.position = startPosition;
		transform.rotation = Quaternion.identity;

		inPlay = false;
	}

	private void Start () {
		rigidBody   = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
		startPosition = transform.position;

		Reset ();
	}
}
