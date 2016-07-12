using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {
	
	private Text starText;

	public enum Status {SUCCESS, FAILURE};
	public int stars = 100;

	private void Start () {
		starText = GetComponent<Text> ();
		UpdateDisplay ();
	}
	
	private void UpdateDisplay() {
		starText.text = stars.ToString();
	}

	public void AddStars(int starsToAdd) {
		stars += starsToAdd;
		UpdateDisplay ();
	}
	
	public Status UseStars(int starsToUse) {
		if (stars >= starsToUse) {
			stars -= starsToUse;
			UpdateDisplay ();
			return Status.SUCCESS;
		} else {
			return Status.FAILURE;
		}
	}
}
