using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		foreach (GameObject thisAttacker in attackerPrefabArray){
			if (isTimeToSpawn (thisAttacker)){
				Spawn(thisAttacker);
			}
		}
	}

	bool isTimeToSpawn(GameObject attackerGameObject){
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();
		float meanSpawnDelay = attacker.spawnPerXSeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay; // calculate how many spawns per second
		if (Time.deltaTime > meanSpawnDelay){ //if you are spawning too fast, it will get capped by the frame rate
			Debug.LogWarning("Spawn rate capped by frame rate");
			}
		float threshold = spawnsPerSecond * Time.deltaTime/5;  // spawns per second * 1 second / 5(lanes). so you get the correct spawn per second

		if (Random.value < threshold){ //??
			return true;
		}else {
			return false;
		}

	}

	void Spawn (GameObject myGameObject){
		GameObject newAttacker = Instantiate(myGameObject)as GameObject;
		newAttacker.transform.parent = transform; // parent to itself
		newAttacker.transform.position = transform.position; // use its own position
	}

}
