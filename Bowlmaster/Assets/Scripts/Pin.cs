using UnityEngine;
using System.Collections;

public class Pin : MonoBehaviour {

	public float standingThreshold = 3f;

	public bool IsStanding() {

		float xTilt = transform.eulerAngles.x;
		float zTilt = transform.eulerAngles.z;

		if (xTilt < standingThreshold || zTilt < standingThreshold) {
			return true;
		} else if (xTilt > 360 - standingThreshold || zTilt > 360 - standingThreshold) {
			return true;
		}

		return false;
	}
}
