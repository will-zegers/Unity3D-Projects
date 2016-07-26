using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	private PinCounter pinCounter;
	private ScoreDisplay scoreDisplay;
	private BowlingBall bowlingBall;
	private PinSetter pinSetter;
	private List<int> rolls;

	public void Bowl(int pinFall) {
		rolls.Add (pinFall);
		Debug.Log (rolls[0]);

		ActionMaster.Action action = ActionMaster.NextAction (rolls);
		if (action != ActionMaster.Action.EndGame) {
			bowlingBall.Reset ();
		}
		pinSetter.PerformAction (action);

		if (action == ActionMaster.Action.EndTurn || action == ActionMaster.Action.Reset) {
			pinCounter.Reset ();
		}

		scoreDisplay.FillRolls(rolls);
		scoreDisplay.FillFrames(ScoreMaster.ScoreCumulative(rolls));

	}

	// Use this for initialization
	void Start () {
		pinCounter = GameObject.FindObjectOfType<PinCounter> ();
		bowlingBall = GameObject.FindObjectOfType<BowlingBall> ();
		pinSetter = GameObject.FindObjectOfType<PinSetter> ();
		scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay> ();

		rolls = new List<int> ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	private void GetAction() {
	}
}
