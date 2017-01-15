using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;

	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

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

	// look through all spawners, and setmyLaneSpanwer if found
	void setMylaneSpawner(){
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> (); // find the object with the script?
		//spawner position is interger
		//if spawner Y position is 1
		//set it as Spawner_1
	
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
