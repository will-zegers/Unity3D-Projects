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
		List<int> frames = new List<int> ();

		for (int i = 0; i < rolls.Count && frames.Count < 10; i++) {
			if (i + 1 < rolls.Count) {
				if (rolls [i] == 10) {
					if (i + 2 < rolls.Count) {
						frames.Add (rolls [i] + rolls [i + 1] + rolls [i + 2]);
					}
				} else if (rolls [i] + rolls [i + 1] == 10) {
					if (i + 2 < rolls.Count) {
						frames.Add (rolls [i] + rolls [i + 1] + rolls [i + 2]);
						i++;
					}
				} else {
					frames.Add (rolls [i] + rolls [i + 1]);
					i++;
				}
			}
		}

		return frames;
	}
}
