using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile, gun;

	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;

	void Start (){
		animator = GameObject.FindObjectOfType<Animator> (); // On your GameObject it self, find its Animator
		// create a parent if necessary
		projectileParent = GameObject.Find ("Projectiles");
		if (!projectileParent) {
			projectileParent = new GameObject("Projectiles");
		}
		SetMylaneSpawner ();
	}

	void Update (){
		if (IsAttackerAheadInLane ()) {
			animator.SetBool ("isAttacking", true);
		} else {
			animator.SetBool ("isAttacking", false);
		}
	}

	// look through all spawners, and setmyLaneSpanwer if found
	void SetMylaneSpawner(){
		Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner> (); // find the object with the script?

		foreach (Spawner spawner in spawnerArray) {
			if (spawner.transform.position.y == transform.position.y) {
				myLaneSpawner = spawner;
				return;
			}

			Debug.LogError (name + "can't find spawner in lane " + spawner.transform.position.y);
		
		}

	
	}

	bool IsAttackerAheadInLane(){
		// Exit if no attackers in lane
		if (myLaneSpawner.transform.childCount <= 0) {
			return false;
		}

		// If there are attackers, are they ahead?
		foreach (Transform child in myLaneSpawner.transform){ //go through each children in myLaneSpawner, course used attacker instead of child. childrens of Spawner are the attacks 
			if (child.transform.position.x > transform.position.x){
				return true;
			}
		}
		// attacker in lane but behind us
		return false;
	}


	private void Fire (){
		GameObject newProjectile = Instantiate(projectile)as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
	}
	

}
