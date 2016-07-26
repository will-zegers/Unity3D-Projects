using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour {

	public Text standingText;

	private GameManager gameManager;
	private int lastStandingCount = -1;
	private int lastSettledCount = 10;
	private bool IsWaitingForPinsToSettle = false;

	private void Start() {
		gameManager = GameObject.FindObjectOfType<GameManager> ();
	}

	private void Update() {
		if (IsWaitingForPinsToSettle) {
			UpdatePinCount ();
		}
	}

	private void UpdatePinCount() {
		standingText.text = CountStanding ().ToString ();
	}

	private int CountStanding() {

		int standingPinCount = 0;
		Pin[] pinArray = GameObject.FindObjectsOfType<Pin> ();

		foreach (Pin pin in pinArray) {
			if (pin.IsStanding()) {standingPinCount++;}
		}

		return standingPinCount;
	}

	private void PinsHaveSettled() {
		IsWaitingForPinsToSettle = false;
		lastStandingCount = -1;
		standingText.color = Color.green;

		UpdatePinCount ();
		gameManager.UpdateScore (lastSettledCount - CountStanding());
	}

	private void WaitForPinsToSettle() {

		IsWaitingForPinsToSettle = true;

		int currentStandingCount = CountStanding ();
		if (currentStandingCount == lastStandingCount) {
			PinsHaveSettled ();
		} else {
			Invoke ("WaitForPinsToSettle", 3);
			lastStandingCount = currentStandingCount;
		}
	}

	private void OnTriggerExit(Collider collider) {
		if (collider.GetComponent<BowlingBall> ()) {
			standingText.color = Color.red;
			WaitForPinsToSettle ();
		}
	}

	public void Reset() {
		lastSettledCount = 10;
		standingText.text = "10";
	}
}