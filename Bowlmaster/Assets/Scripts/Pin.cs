using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public float standingThreshold = 3f;

	private Rigidbody rigidBody;

	public bool IsStanding() {

		float xTilt = transform.eulerAngles.x;
		float zTilt = transform.eulerAngles.z;

		if (xTilt > standingThreshold && xTilt < 360 - standingThreshold) {
			return false;
		}

		if (zTilt > standingThreshold && zTilt < 360 - standingThreshold) {
			return false;
		}

		return true;
	}

	public void Raise() {
		transform.Translate (new Vector3 (0, PinSetter.distanceToRaise, 0), Space.World);
		rigidBody.useGravity = false;
		transform.rotation = Quaternion.Euler(Vector3.zero);
	}

	public void Lower() {
		transform.Translate (new Vector3 (0, -PinSetter.distanceToRaise, 0), Space.World);
		transform.eulerAngles = Vector3.zero;
		rigidBody.useGravity = true;
	}

	private void Start() {
		rigidBody = GetComponent<Rigidbody> ();
	}
}
