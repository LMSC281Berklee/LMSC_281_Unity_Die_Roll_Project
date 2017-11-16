﻿//Conrad Robertson
//LMSC-281
//Fall 2016
//Die Roll Project

//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class ApplyForceInRandomDirection : MonoBehaviour
{
	public string buttonName = "Fire1";
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
	public ForceMode forceMode;

	//Allows for autorun functionality when TRUE
	public bool autoRun = false;

	void Start () {
		Time.timeScale = 5.0F;
	}

	// Update is called once per frame
	void Update ()
	{

		//roll die with AI by applying force to the die
		if (autoRun) {
			
			GetComponent<Rigidbody>().AddForce(Random.onUnitSphere*forceAmount,forceMode);
			GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere*torqueAmount,forceMode);
		}
	}


}
