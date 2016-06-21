using UnityEngine;
using System.Collections;

public class Spaceship : MonoBehaviour {

	public float speed = 15.0f;
	public float padding = 0.5f;

	private float xMin = -5;
	private float xMax = 5;

	// Use this for initialization
	void Start () {
		float cameraDistance = transform.position.z - Camera.main.transform.position.z;
		xMin = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, cameraDistance)).x;
		xMax = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, cameraDistance)).x;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > (xMin + padding)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
		} else if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < (xMax - padding)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		
	}
}
