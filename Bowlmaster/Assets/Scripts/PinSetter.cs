using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public int lastStandingCount = -1;
	public Text pinCountText;
	public BowlingBall bowlingBall;
	public GameObject pinSet;
	public static float distanceToRaise = 20f;

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
		Pin[] pinArray = GameObject.FindObjectsOfType<Pin> ();

		foreach (Pin pin in pinArray) {
			if (pin.IsStanding ()) {
				pin.Raise ();
			}
		}
	}

	public void LowerPins() {
		Pin[] pinArray = GameObject.FindObjectsOfType<Pin> ();

		Debug.Log (pinArray.Length);
		foreach (Pin pin in pinArray) {
				pin.Lower ();
		}
		UpdatePinCount ();
	}

	public void RenewPins() {
		Instantiate (pinSet, new Vector3 (0, distanceToRaise, 1829), Quaternion.identity);
	}

	private void Update() {
		if (ballEnteredBox) {
			UpdatePinCount ();
		}
	}

	private void UpdatePinCount() {
		pinCountText.text = CountStanding ().ToString ();
	}

	private void UpdateStandingCountAndSettle() {

		int currentStandingCount = CountStanding ();

		if (lastStandingCount == currentStandingCount) {
			PinsHaveSettled ();
		} else {
			lastStandingCount = currentStandingCount;
			Invoke ("UpdateStandingCountAndSettle", 3);
		}
	}

	private void PinsHaveSettled() {
		lastStandingCount = -1;
		pinCountText.color = Color.green;
		ballEnteredBox = false;
		UpdatePinCount ();
		bowlingBall.Reset ();
	}

	private void OnTriggerEnter(Collider collider) {
		if (collider.GetComponent<BowlingBall>()) {
			ballEnteredBox = true;
			pinCountText.color = Color.red;
			if (ballEnteredBox) {
				UpdateStandingCountAndSettle ();
			}
		}
	}
}
