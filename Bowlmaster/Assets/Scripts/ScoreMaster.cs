using UnityEngine;	
using System.Collections;
using System.Collections.Generic;

public class ScoreMaster : MonoBehaviour {

	// Returns a list of cumulative scores, like a normal score card
	public static List<int> ScoreCumulative(List<int> rolls) {

		List<int> cumulativeScores = new List<int> ();
		int runningTotal = 0;

		foreach (int frameScore in ScoreFrames(rolls)) {
			runningTotal += frameScore;
			cumulativeScores.Add (runningTotal);
		}
		return cumulativeScores;
	}

	// Returns a list of individual frame scores, not cumulative
	public static List<int> ScoreFrames (List<int> rolls) {
		List<int> frameList = new List<int> ();

		for (int i = 0; i < rolls.Count && frameList.Count < 10; ) {
			if (i + 1 < rolls.Count) {
				if (rolls [i] == 10) {
					if (i + 2 < rolls.Count) {
						frameList.Add (rolls [i] + rolls [i + 1] + rolls [i + 2]);
						i += 1;
					}
				} else if (rolls[i] + rolls[i+1] == 10) {
					if (i + 2 < rolls.Count) {
						frameList.Add (rolls [i] + rolls [i + 1] + rolls [i + 2]);
						i += 2;
					}
				} else {
					frameList.Add (rolls [i] + rolls [i + 1]);
					i += 2;
				}
			}
		}

		return frameList;
	}
}
