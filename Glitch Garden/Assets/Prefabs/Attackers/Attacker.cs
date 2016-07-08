﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Health))]
public class Attacker : MonoBehaviour {

	private float currentSpeed;
	private GameObject currentTarget;
	public float damage = 10f;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!currentTarget) {
			animator.SetBool ("isAttacking", false);
		}
		transform.Translate (Vector3.left * currentSpeed * Time.deltaTime);
	}

	void OnTriggerEnter2D() {
		Debug.Log (name+" trigger enter");
	}

	public void setCurrentSpeed(float speed) {
		currentSpeed = speed;
	}

	public void StrikeCurrentTarget() {

		if (currentTarget) {
			Health targetHealth = currentTarget.GetComponent<Health> ();
			if (targetHealth) {
				Debug.Log ("damage:" + damage);
				targetHealth.DealDamage(damage);
			}
		}
	}

	public void Attack(GameObject obj) {
		currentTarget = obj;
	}
}
