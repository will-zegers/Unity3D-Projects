using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private PinCounter pinCounter;
	private ScoreDisplay scoreDisplay;
	private BowlingBall bowlingBall;
	private PinSetter pinSetter;
	private ActionMaster actionMaster;
	private List<int> pins;

	public void UpdateScore(int pinFall) {
		pins.Add (pinFall);
		GetAction ();
	}

	// Use this for initialization
	void Start () {
		pinCounter = GameObject.FindObjectOfType<PinCounter> ();
		bowlingBall = GameObject.FindObjectOfType<BowlingBall> ();
		pinSetter = GameObject.FindObjectOfType<PinSetter> ();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay> ();

		pins = new List<int> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void GetAction() {
		ActionMaster.Action action = ActionMaster.NextAction (pins);
		pinSetter.PerformAction (action);

		if (action == ActionMaster.Action.EndTurn || action == ActionMaster.Action.Reset) {
			pinCounter.Reset ();
		}

		if (action != ActionMaster.Action.EndGame) {
			scoreDisplay.FillRollCard (pins);
			bowlingBall.Reset ();
		}
	}
}
