using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public int lastStandingCount = -1;
	public Text pinCountText;
	public BowlingBall bowlingBall;
	public float distanceToRaise = 40f;

	private bool ballEnteredBox = false;
	private float lastChangeTime;
	private Animator animator;

	public int CountStanding() {

		int standingPinCount = 0;
		Pin[] pinArray = GameObject.FindObjectsOfType<Pin> ();

		foreach (Pin pin in pinArray) {
			if (pin.IsStanding()) {standingPinCount++;}
		}
		return standingPinCount;
	}

	public void RaisePins() {

	}

	public void LowerPins() {

	}

	private void Start() {
		animator = GetComponent<Animator> ();
	}

	private void Update() {
		pinCountText.text = CountStanding ().ToString ();
	}

	private void CheckStanding() {

		int currentStandingCount = CountStanding ();

		Debug.Log (lastStandingCount + " " + currentStandingCount);
		if (lastStandingCount == currentStandingCount) {
			PinsHaveSettled ();
		} else {
			lastStandingCount = currentStandingCount;
			Invoke ("CheckStanding", 3);
		}
		//Update the lastStandingCount
		//Call PinsHaveSettled when they have
	}

	private void PinsHaveSettled() {
		lastStandingCount = -1;
		pinCountText.color = Color.green;
		ballEnteredBox = false;
		bowlingBall.Reset ();
	}

	private void OnTriggerEnter(Collider collider) {
		if (collider.GetComponent<BowlingBall>()) {
			ballEnteredBox = true;
			pinCountText.color = Color.red;
			if (ballEnteredBox) {
				CheckStanding ();
			}
		}
	}

	private void OnTriggerExit(Collider collider) {
		if (collider.gameObject.GetComponent<Pin>()) {
			Destroy (collider.gameObject);
		}
	}
}
