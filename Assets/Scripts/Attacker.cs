using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Tooltip ("one comes out every X seconds")]
	public float spawnPerXSeconds;
	private float currentSpeed;
	private GameObject currentTarget;
	private Health health;
	private Animator anim;
	
	void Start () {
		anim = GetComponent<Animator>();
		}
	
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget){
			anim.SetBool ("isAttacking", false);
		}
	}

	void OnTriggerEnter2D(){
		//Debug.Log (name + "trigger enter");
	}
	
	public void SetSpeed (float speed){  // call this "function" in animation (animation can call functions instead of variables)
		currentSpeed = speed;
	}

	// called from the animator at the time of the actual blow
	public void StrikeCurrentTarget(float damage){
		//Debug.Log(name + " doing damage " + damage); to log dmg
		if (currentTarget){
		// course puts it all in one line: Health health = currentTarget.GetComponent<Health>();
			health = currentTarget.GetComponent<Health>();
			if (health){
				health.HandleHits(damage);
			}
		}
	}
	
	
	public void Attack(GameObject obj){
		currentTarget = obj;
		
	}
	
}
