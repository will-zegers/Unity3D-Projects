using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {

	public GameObject pinSet;
	public static float distanceToRaise = 20f;

	private Animator animator;

	private void Start() {
		animator = GetComponent<Animator> ();
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
	}

	public void PerformAction(ActionMaster.Action action) {
		if (action == ActionMaster.Action.Tidy) {
			animator.SetTrigger ("tidyTrigger");
		} else if (action == ActionMaster.Action.EndTurn) {
			animator.SetTrigger ("resetTrigger");
		} else if (action == ActionMaster.Action.Reset) {
			animator.SetTrigger ("resetTrigger");
		} else {
			throw new UnityException ("Don't know how to handle action " + action);
		}
	}
}
