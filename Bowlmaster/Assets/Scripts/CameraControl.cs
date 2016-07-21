using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public BowlingBall bowlingBall;
	private Vector3 offset; // = new Vector3(0, 20, -200);

	// Use this for initialization
	void Start () {
		offset = transform.position - bowlingBall.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 bowlingBallPosition = bowlingBall.transform.position;
		if (bowlingBallPosition.z <= 1829f) {
			transform.position = bowlingBallPosition + offset;
		}
	}
}
