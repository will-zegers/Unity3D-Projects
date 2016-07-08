using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float currentHealth = 100f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void DealDamage(float damage) {
		currentHealth -= damage;
		if (currentHealth <= 0) {
			DestroyObject();
		}
	}

	public void DestroyObject() {
		Destroy (gameObject);
	}
}
