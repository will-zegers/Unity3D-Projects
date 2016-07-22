using UnityEngine;
using System.Collections;

public class ActionMaster {

	public enum Action {
		Tidy,
		Reset,
		EndTurn,
		EndGame
	}
	private int bowl = 1;
	private int[] bowls = new int[22];

	public Action Bowl(int pins) {

		if (pins < 0 || pins > 10) {
			throw new UnityException ("Invalid pins!");
		}

		bowls [bowl] = pins;
		if (bowl == 21) {
			return Action.EndGame;
		}

		if (pins == 10) {
			if (bowl == 19 || bowl == 20) {
				bowl += 1;
				return Action.Reset;
			} else {
				bowl += 2;
				return Action.EndTurn;
			}
		}

		if (bowl == 20 && pins + bowls[bowl-1] == 10) {
			bowl += 1;
			return Action.Reset;
		} else if (bowl % 2 != 0) {
			bowl += 1;
			return Action.Tidy;
		} else {
			bowl += 1;
			return Action.EndTurn;
		}
			
		throw new UnityException ("Not sure what action to return!");
	}
}
