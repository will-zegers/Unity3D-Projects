using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public static float xOffset = 270f;
	public static float zOffset = 0f;
	public float standingThreshold = 3f;

	private Rigidbody rigidBody;

	public bool IsStanding() {

		float xTilt = transform.eulerAngles.x - xOffset;
		float zTilt = transform.eulerAngles.z;

		Debug.Log (xTilt + " " + zTilt);

		if (xTilt > standingThreshold || xTilt < -standingThreshold) {
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
	}

	public void Lower() {
		transform.Translate (new Vector3 (0, -PinSetter.distanceToRaise, 0), Space.World);
		rigidBody.useGravity = true;
	}

	private void Start() {
		rigidBody = GetComponent<Rigidbody> ();
	}
}
