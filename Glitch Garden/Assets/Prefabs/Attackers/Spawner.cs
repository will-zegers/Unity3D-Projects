using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public static int seed = 0;
	public GameObject[] attackerPrefabArray;

	private int numberOfLanes;

	private void Start() {
		numberOfLanes = GameObject.FindObjectsOfType<Spawner> ().Length;
	}

	private bool isTimeToSpawn(GameObject attackerGameObject) {

		Attacker attacker = attackerGameObject.GetComponent<Attacker> ();

		Random.seed = seed++;

		return Random.value < (Time.deltaTime / (numberOfLanes * attacker.appearancePeriod));
	}

	private void Spawn(GameObject myGameObject) {
		GameObject obj = Instantiate (myGameObject) as GameObject;
		obj.transform.parent = transform;
		obj.transform.position = transform.position;
	}

	private void Update() {
		foreach (GameObject thisAttacker in attackerPrefabArray) {
			if (isTimeToSpawn (thisAttacker)) {
				Spawn (thisAttacker);
			}
		}
	}
}
