using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		PlayerPrefsManager.UnlockLevel (3);
		print (PlayerPrefsManager.IsLevelUnlocked (3));
		print (PlayerPrefsManager.IsLevelUnlocked (4));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
