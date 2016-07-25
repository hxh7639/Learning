using UnityEngine;
using System.Collections;

public class DestorySelfAfterTime : MonoBehaviour {

public float timeUntilDestory = 1f;

	// Use this for initialization
	void Start () {
	
		Invoke ("DestorySelf", timeUntilDestory);
	}
	
	void DestorySelf(){
		Destroy(gameObject);
	}

}
