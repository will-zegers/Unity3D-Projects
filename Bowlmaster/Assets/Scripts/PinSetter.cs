using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public Text pinCountText;
	public GameObject pinSet;
	public BowlingBall bowlingBall;
	public static float distanceToRaise = 20f;

	private int lastStandingCount = -1;
	private int lastSettledCount = 10;
	private float lastChangeTime;
	private Animator animator;
	private ActionMaster actionMaster;

	public void RaisePins() {
		Pin[] pinArray = GameObject.FindObjectsOfType<Pin> ();

		foreach (Pin pin in pinArray) {
			if (pin.IsStanding ()) {
				pin.Raise ();
				pin.transform.rotation = Quaternion.Euler(Vector3.zero);
			}
		}
	}

	public void LowerPins() {
		Pin[] pinArray = GameObject.FindObjectsOfType<Pin> ();
		foreach (Pin pin in pinArray) {
				pin.Lower ();
		}
	}

	public void RenewPins() {
		Instantiate (pinSet, new Vector3 (0, distanceToRaise, 1829), Quaternion.identity);
		Pin[] pinArray = GameObject.FindObjectsOfType<Pin> ();
		Debug.Log (pinArray.Length);
	}

	private void Start() {
		actionMaster = new ActionMaster();
		animator = GetComponent<Animator> ();
		Debug.Log (GameObject.FindObjectsOfType<Pin> ().Length);
	}

	private void Update() {
			UpdatePinCount ();
	}

	private void UpdatePinCount() {
		pinCountText.text = CountStanding ().ToString ();
	}

	public void UpdateStandingCountAndSettle() {

		pinCountText.color = Color.red;
		int currentStandingCount = CountStanding ();

		if (lastStandingCount == currentStandingCount) {
			ActionMaster.Action action = actionMaster.Bowl (lastSettledCount - currentStandingCount);
			if (action == ActionMaster.Action.Tidy) {
				animator.SetTrigger ("tidyTrigger");
				lastSettledCount = currentStandingCount;
			} else if (action == ActionMaster.Action.EndTurn) {
				animator.SetTrigger ("resetTrigger");
				lastSettledCount = 10;
			} else if (action == ActionMaster.Action.Reset) {
				animator.SetTrigger ("resetTrigger");
				lastSettledCount = 10;
			} else {
				throw new UnityException ("Don't know how to handle action " + action);
			}
			PinsHaveSettled ();
		} else {
			lastStandingCount = currentStandingCount;
			Invoke ("UpdateStandingCountAndSettle", 3);
		}
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

		lastStandingCount = -1;
		pinCountText.color = Color.green;
		UpdatePinCount ();
		bowlingBall.Reset ();
	}
}
