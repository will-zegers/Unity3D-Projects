using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Health))]
public class Defender : MonoBehaviour {
	
	public int starCost = 100;
	private StarDisplay starDisplay;

	private void Start() {
		starDisplay = GameObject.FindObjectOfType<StarDisplay> ();
	}

	public void AddStars(int starCount) {
		starDisplay.AddStars (starCount);
	}
}
