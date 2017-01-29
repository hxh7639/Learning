using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

	public GameObject defenderPrefab;
    public static GameObject selectedDefender;
	
    private Button[] buttonArray;
    private Text costText;
  
	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<Button>();

        costText = GetComponentInChildren<Text>();
        if(!costText) {Debug.LogWarning(name + " cannot find Cost");}
        costText.text = defenderPrefab.GetComponent<Defenders>().starCost.ToString();


	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown (){
		// Debug.Log (name + " clicked"); log the selected.
		foreach (Button thisButton in buttonArray) { //set all to gray and then the clicked to white
			thisButton.GetComponent<SpriteRenderer> ().color = Color.gray; // course used color.black, here i used gray.
		}
		GetComponent<SpriteRenderer> ().color = Color.white;
		selectedDefender = defenderPrefab;

	}
} 
