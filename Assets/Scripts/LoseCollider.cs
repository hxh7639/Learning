using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

private LevelManager levelManager;

	void Start () {
		levelManager = GameObject.Find("Level Manager").GetComponent<LevelManager>(); //Course uses GameObject.FindObjectOfType<LevelManager>();
		}

	void OnTriggerEnter2D(){
		print("Lose");
		levelManager.LoadLevel("03b Lose");
	}

}
