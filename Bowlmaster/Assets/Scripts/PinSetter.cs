using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public int lastStandingCount = -1;
	public Text pinCountText;
	public GameObject pinSet;
	public BowlingBall bowlingBall;
	public static float distanceToRaise = 20f;

	private int lastSettledCount = 10;
	private bool ballEnteredBox = false;
	private float lastChangeTime;
	private Animator animator;
	private ActionMaster actionMaster;

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

	private void UpdateStandingCountAndSettle() {

		int currentStandingCount = CountStanding ();

		if (lastStandingCount == currentStandingCount) {
			ActionMaster.Action action = actionMaster.Bowl (lastSettledCount - currentStandingCount);
			if (action == ActionMaster.Action.Tidy) {
				animator.SetTrigger ("tidyTrigger");
			} else if (action == ActionMaster.Action.EndTurn) {
				animator.SetTrigger ("resetTrigger");
				lastSettledCount = 10;
			} else if (action == ActionMaster.Action.Reset) {
				animator.SetTrigger ("resetTrigger");
				lastSettledCount = 10;
			} else {
				throw new UnityException ("Don't know how to handle action " + action);
			}
			lastSettledCount = currentStandingCount;
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
