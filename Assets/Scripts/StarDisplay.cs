﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour {


	private Text startext;
	private int starAmount = 100;
	public enum Status {SUCCESS, FAILURE};
	
 
	// Use this for initialization
	void Start () {
		startext = GameObject.Find("Stars").GetComponent<Text>(); //course used just getcomponent<text>.. because it is on the same object
		startext.text = starAmount.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void AddStars(int amount){
		starAmount += amount;
		startext.text = starAmount.ToString(); // course factored this out and made it into another function to call here.
	}
	public Status UseStars(int amount){
		if (starAmount >= amount)
		{
			starAmount -= amount;
			startext.text = starAmount.ToString();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}

		
}
