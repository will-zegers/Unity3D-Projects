using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActionMaster {

	public enum Action {
		Tidy,
		Reset,
		EndTurn,
		EndGame,
	}
	private int bowl = 1;
	private int[] bowls = new int[22];

	public Action Bowl(int pins) { // TODO make private

		Debug.Log (pins);
		if (pins < 0 || pins > 10) {
			throw new UnityException ("Invalid pins!");
		}
			
		bowls [bowl] = pins;

		// If player bowls the extra bowl, end the game.
		if (bowl == 21) {
			return Action.EndGame;
		}

		// If player knocks down all pins...
		if (pins == 10) {

			//...on last frame, they get an extra turn.
			if (bowl == 19 || bowl == 20) {
				bowl += 1;
				return Action.Reset;

			// ...otherwise its a regular strike and their turn ends.
			} else {
				if (bowl % 2 == 0) {
					bowl += 1;
				} else {
					bowl += 2;
				}
				return Action.EndTurn;
			}
		}

		// If player is on last turn in the last frame (and hasn't knocked down 10 pins)...
		if (bowl == 20) {

			// ...and they didn't get a strike at the beginning of the frame...
			if (bowls [19] != 10) {

				// ...but they picked up the spare, reset the pins for bowl 21.
				if (pins + bowls [19] == 10) {
					bowl += 1;
					return Action.Reset;
				
				// ...but didn't pick up the spare, the game ends for the player.
				} else
					return Action.EndGame;

			// ...but they got a strike on the previous bowl, tidy the lane for the extra bowl.
			} else {
				bowl += 1;
				return Action.Tidy;
			}
		}

		// If it's mid frame, tidy the pins for the latter half of the frame.
		if (bowl % 2 != 0) {
			bowl += 1;
			return Action.Tidy;
		
		// Otherwise, the frame is over and the player's turn ends
		} else {
			bowl += 1;
			return Action.EndTurn;
		}
			
		throw new UnityException ("Not sure what action to return!");
	}

	public static Action NextAction (List<int> pinFalls) {

		Action nextAction = new Action ();
		ActionMaster actionMaster = new ActionMaster ();
		foreach (int pinFall in pinFalls) {
			nextAction = actionMaster.Bowl (pinFall);
		}
		return nextAction;
	}
}
