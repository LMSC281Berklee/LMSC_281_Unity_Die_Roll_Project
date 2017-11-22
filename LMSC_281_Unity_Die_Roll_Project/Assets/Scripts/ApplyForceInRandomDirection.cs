//By Abhi Acharya
//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ApplyForceInRandomDirection : MonoBehaviour
{
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;

	public ForceMode forceMode;
	public DisplayCurrentDieValue valueOfDie;
	private GameController gameController; 

	public bool automateRoll = false;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent<GameController> ();
		} 
		else
		{
			Debug.Log ("Cannot find 'GameController' Script");
		}
		   valueOfDie = GetComponent<DisplayCurrentDieValue> ();
		   StartCoroutine (RollProcess ());
	}
		

	// Update is called once per frame
	void Update ()
	{
		if (!GetComponent <Rigidbody> ().IsSleeping ()) 
		{
			automateRoll = false;
		}
	}


	void DieRoll ()
	{		
		if (!automateRoll && GetComponent<Rigidbody> ().IsSleeping ()) 
		{
			GetComponent<Rigidbody> ().AddForce (Random.onUnitSphere * forceAmount, forceMode);
			GetComponent<Rigidbody> ().AddTorque (Random.onUnitSphere * torqueAmount, forceMode);
			automateRoll = true;
		}			
	}

	IEnumerator RollProcess ()
	{
		yield return new WaitForSeconds (1);

		for (int i = 0; i < gameController.rolls; i++)
		{
			DieRoll ();
			yield return new WaitForSeconds (1);
			valueOfDie.InsertResults ();
		}
		valueOfDie.GetRatio ();

	}
}

