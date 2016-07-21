using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	private void OnTriggerExit(Collider collider) {
		if (collider.gameObject.GetComponent<Pin>()) {
			Destroy (collider.gameObject);
		}
	}	
}
