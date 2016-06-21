using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 10.92f;
	public float height = 11.5f;

	private int direction = 1;
	public float speed = 3.0f;
	private float xMin;
	private float xMax;

	// Use this for initialization
	void Start () {

		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = child.transform;
		}

		float cameraDistance = transform.position.z - Camera.main.transform.position.z;
		xMin = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, cameraDistance)).x;
		xMax = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, cameraDistance)).x;
		Mathf.Clamp (speed, 1, 10);
	}

	private float getSpeed() {
		return speed * Time.deltaTime;
	}

	void OnDrawGizmos () {
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x >= (xMax - width/2.2)) {
			direction = -1;
		} else if (transform.position.x <= (xMin + width/2.2)) {
			direction = 1;
		}
		transform.position += new Vector3 (direction * getSpeed (), 0);
	}
}
