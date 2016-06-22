using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("DestoryExplosion", 1f);
	}

	void DestoryExplosion() {
		Destroy (this.gameObject);	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
