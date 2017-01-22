using UnityEngine;
using System.Collections;

public class Defenders : MonoBehaviour {

	private StarDisplay starDisplay;
	public int starCost = 100;

	void Start() {
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();

	}
	// Only beingn used as a tag for now!
	public void AddStar (int amount){
		starDisplay.AddStars(amount);
	}


}
