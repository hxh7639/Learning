using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Attacker))]
public class Fox : MonoBehaviour {

	public Animator anim;

	private Attacker attacker;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();	
	}
	
	// Update is called once per frame
	void Update () {

	}
	
	
	void OnTriggerEnter2D(Collider2D collider){
		GameObject obj = collider.gameObject;
		
		// leave the method if not colliding with defender
		if(!obj.GetComponent<Defenders>()){
			return;
		}
		
		if (obj.GetComponent<Stone>()){
			anim.SetTrigger ("jump Trigger");
		} else {
			anim.SetBool ("isAttacking", true);
			attacker.Attack (obj);
			
		} 
		
	
		// Debug.Log("FOX collide with " + collider); log fox collider
	}
}
