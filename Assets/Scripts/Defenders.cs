using UnityEngine;
using System.Collections;

public class Defenders : MonoBehaviour {

	private StarDisplay starDisplay;

	void Start() {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();

	}
	// Only beingn used as a tag for now!
	public void AddStar (int amount){
		starDisplay.AddStars(amount);
	}


}
