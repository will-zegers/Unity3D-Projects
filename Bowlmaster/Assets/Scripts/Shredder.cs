using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour {

	private void OnTriggerExit(Collider collider) {

		Transform parentTransform = collider.transform.parent;

		// Check if the collider has a parent and, if so, if it has a Pin component
		// (i.e., it's a pin)
		if (parentTransform && parentTransform.gameObject.GetComponent<Pin> ()) {
			Destroy (collider.transform.parent.gameObject);
		}
	}	
}
