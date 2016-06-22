using UnityEngine;
using System.Collections;

public class FormationController : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 10.92f;
	public float height = 11.5f;
	public float speed = 3.0f;
	public float spawnDelay = 0.25f;

	private int direction = 1;
	private float xMin;
	private float xMax;

	// Use this for initialization
	void Start () {

		SpawnUntilFull ();

		float cameraDistance = transform.position.z - Camera.main.transform.position.z;
		xMin = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, cameraDistance)).x;
		xMax = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, cameraDistance)).x;

		Mathf.Clamp (speed, 1, 10);
	}

	float GetSpeed() {
		return speed * Time.deltaTime;
	}

	void SpawnUntilFull() {
		Transform freePosition = NextFreePosition ();
		if (freePosition) {
			GameObject enemy = Instantiate (enemyPrefab, freePosition.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = freePosition;
			Invoke ("SpawnUntilFull", spawnDelay);
		}
	}

	void OnDrawGizmos () {
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	}

	Transform NextFreePosition(){
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount == 0) {
				return childPositionGameObject;
			}
		}
		return null;

	}

	bool AllMembersDead() {
		foreach (Transform childPositionGameObject in transform) {
			if (childPositionGameObject.childCount > 0) {
				return false;
			}
		}
		return true;
	}
	
	// Update is called once per frame
	void Update () {

		if (AllMembersDead ()) {
			SpawnUntilFull();
		}

		if (transform.position.x >= (xMax - width/2.2)) {
			direction = -1;
		} else if (transform.position.x <= (xMin + width/2.2)) {
			direction = 1;
		}
		transform.position += new Vector3 (direction * GetSpeed (), 0);
	}
}
