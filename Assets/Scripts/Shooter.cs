using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;
	private GameObject projectileParent;
	private Animator animator;

	void Start (){
		animator = GameObject.FindObjectOfType<Animator> (); // On your GameObject it self, find its Animator
		projectileParent = GameObject.Find ("Projectiles");
		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
	}

	void Update (){
		if (isAttackerAheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	bool isAttackerAheadInLane(){
		return false;
	}


	private void Fire (){
		GameObject newProjectile = Instantiate(projectile)as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
	

}
