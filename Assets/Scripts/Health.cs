using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public float health = 100f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void HandleHits (float damage){
		health -= damage;
		// Debug.Log(name + "current health: " + health); - log current health
		if (health <= 0) {
			// optionally trigger an animation then destroy
			DestoryObject();
		}
	}
	
	// course made it into a separate function just so the animator event can call it.
	public void DestoryObject(){
		Destroy(gameObject);
	}
}
