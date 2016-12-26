using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;

	private Button[] buttonArray;
	public static GameObject selectedDefender;

	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button>();


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown (){
		// Debug.Log (name + " clicked"); log the selected.
		foreach (Button thisButton in buttonArray) {
			thisButton.GetComponent<SpriteRenderer> ().color = Color.gray; // course used color.black, here i used gray.
		}
		GetComponent<SpriteRenderer> ().color = Color.white;
		selectedDefender = defenderPrefab;

	}
} 
