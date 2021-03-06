﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	private GameObject defenderParent;
    private StarDisplay starDisplay;

	void Start (){
		defenderParent = GameObject.Find ("Defenders");
		if (!defenderParent) {
			defenderParent = new GameObject("Defenders");
		}
        starDisplay = GameObject.Find("Stars").GetComponent<StarDisplay>(); //course used GameObject.FindObjectOfType<StarDisplay>
	}

	void OnMouseDown(){
		Vector2 rawPos = CalculateWorldPointOfMouseClick(); //calculate mouse position to world position
		Vector2 roundedPos = SnapToGrid(rawPos); // snap that to round number or snap pos to the center of the box
        GameObject defender = Button.selectedDefender;

        int defenderCost = defender.GetComponent<Defenders>().starCost; // we found defender above, now find its "Defenders" script, then find starCost in it.
        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(roundedPos, defender); 
        }
        else {
            Debug.Log("Insufficient Stars");
        }

	}

    void SpawnDefender(Vector2 roundedPos, GameObject defender)
    {
        GameObject newDef = Instantiate(defender, roundedPos, Quaternion.identity) as GameObject;
        // instantiate the selected prefab as game object
        newDef.transform.parent = defenderParent.transform;
        // child it to "Defenders"
    }

	Vector2 SnapToGrid (Vector2 rawWorldPos){
		float newX = Mathf.RoundToInt(rawWorldPos.x);
		float newY = Mathf.RoundToInt(rawWorldPos.y);
		return new Vector2 (newX, newY);
	
	}

	Vector2 CalculateWorldPointOfMouseClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		float distanceFromCamera = 10f; // not really needed since its 2D game - authographic camera.

		Vector3 weirdTriplet = new Vector3 (mouseX, mouseY, distanceFromCamera); // should work without the Z value
		Vector2 worldPos = myCamera.ScreenToWorldPoint (weirdTriplet);
		return worldPos;
	}

}
