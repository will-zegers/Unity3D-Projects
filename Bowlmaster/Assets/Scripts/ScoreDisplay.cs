using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScoreDisplay : MonoBehaviour {

	public Text[] rollTexts, frameTexts;

	public void FillRolls(List<int> rolls) {
		string output = FormatRolls (rolls);
		for (int i = 0; i < output.Length; i++) {
			rollTexts [i].text = output [i].ToString();
		}
	}

	public void FillFrames (List<int> frames) {
		for (int i = 0; i < frames.Count; i++) {
			frameTexts[i].text = frames [i].ToString();
		}
	}

	public static string FormatRolls (List<int> rolls) {
		string output = "";

		for (int i = 0; i < rolls.Count; i += 2) {
			if (rolls [i] == 10) {
				if (output.Length < 18) {
					output += " ";
				}
				output += "X";
				i--;
			} else {
				if (rolls[i] == 0) {
					output += "-";
				} else {
					output += rolls [i].ToString ();
				}
				if (i + 1 < rolls.Count) {
					if (rolls [i] + rolls [i + 1] == 10) {
						output += "/";
					} else if (rolls[i+1] == 0) {
						output += "-";
					} else {
						output += rolls [i + 1].ToString ();
					}
				}
			}
		}

		return output;
	}
}
