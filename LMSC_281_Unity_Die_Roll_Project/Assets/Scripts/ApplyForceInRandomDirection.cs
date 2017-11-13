﻿//example provided by http://www.cookingwithunity.com/

//TY I AM TESTING THIS RIGHT NOW JUST MAKING SOME CHANGES.

using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ApplyForceInRandomDirection : MonoBehaviour
{
	public string buttonName = "Fire1";
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
	public ForceMode forceMode;

	public bool rollTheDie = false;
	public int rollCount = 0;

	// Update is called once per frame
	void Update ()
	{
		if (Input.GetButtonDown (buttonName))
		{
			rollTheDie = true;
		}

	
		if (rollTheDie)
			{
				GetComponent<Rigidbody> ().AddForce (Random.onUnitSphere * forceAmount, forceMode);
				GetComponent<Rigidbody> ().AddTorque (Random.onUnitSphere * torqueAmount, forceMode);
			rollCount = rollCount + 1;
			CheckCount();

			}

	}

	void CheckCount()
	{
		if (rollCount > 99) 
		{
			rollTheDie = false;
		}


	}

}
