using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarecrow : MonoBehaviour {

    private Animator anim;
    private Health targetHealth;
    public float damage = 10;


	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
        

    void OnTriggerStay2D(Collider2D collider){
        GameObject obj = collider.gameObject;
        if (obj.GetComponent<Attacker>())
        {
            targetHealth = obj.GetComponent<Health>();
            anim.SetTrigger("underAttack Trigger");
        }
    }

    void HitCurrentTarget(){
        targetHealth.HandleHits(damage);
    }
}
