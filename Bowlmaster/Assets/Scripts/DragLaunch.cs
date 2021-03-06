﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof(BowlingBall))]
public class DragLaunch : MonoBehaviour {

	private BowlingBall bowlingBall;

	private float startTime;
	private Vector3 dragStart;

	// Use this for initialization
	void Start () {
		bowlingBall = GetComponent<BowlingBall> ();
	}

	public void MoveStart(float xNudge) {

		float laneWidth = GameObject.Find ("Floor").transform.lossyScale.x;
		bool IsBallInBounds = Mathf.Abs (bowlingBall.transform.position.x + xNudge) < laneWidth / 2;

		if (!bowlingBall.inPlay && IsBallInBounds) {
			bowlingBall.transform.Translate (new Vector3 (xNudge, 0, 0), Space.World);
		}
	}

	public void DragStart() {
		// Capture time and position of drag start
		startTime = Time.time;
		dragStart = Input.mousePosition;
	}

	public void DragEnd() {
		// Launch the ball
		Vector3 deltaPosition = Input.mousePosition - dragStart;
		float deltaTime = Time.time - startTime;

		Vector3 mouseVelocity = deltaPosition / deltaTime;
		if (!bowlingBall.inPlay) {
			bowlingBall.Launch (new Vector3 (mouseVelocity.x, 0, mouseVelocity.y));
		}
	}
}
