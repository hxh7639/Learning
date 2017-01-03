using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;

	void OnMouseDown(){
		print (Input.mousePosition);
		print (SnapToGrid(CalculateWorldPointOfMouseClick()));

	
	}

	Vector2 SnapToGrid (Vector2 rawWorldPos){
		float newX = Mathf.RoundToInt(CalculateWorldPointOfMouseClick)
		float newY

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
