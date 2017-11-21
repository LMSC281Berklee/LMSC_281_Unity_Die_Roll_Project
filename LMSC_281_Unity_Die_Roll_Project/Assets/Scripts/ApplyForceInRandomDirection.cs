//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ApplyForceInRandomDirection : MonoBehaviour
{
	//getting input from the mouse click 1 (called Fire1)
	public string buttonName = "Fire1";
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
	public ForceMode forceMode;
	public bool automateRoll = false; 

	private bool rollComplete = false;
	public int mainCounter = 0;
	
	

	// Update is called once per frame
	void Update ()
	{
		//get mouse click
		if (automateRoll)
		// if(Input.GetButtonDown(buttonName)) 
		{
		//applying a random force
			GetComponent<Rigidbody>().AddForce(Random.onUnitSphere*forceAmount,forceMode);
			GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere*torqueAmount,forceMode);

			automateRoll = false; 
		}
		if(GetComponent<Rigidbody>().IsSleeping() && !rollComplete) //& mainCounter < 100
		{
			rollComplete = true;
 			Debug.Log("Die roll complete, die is at rest");
			//for loop doing 100 rolls
			automateRoll = true;

		
		}
		else if(!GetComponent<Rigidbody>().IsSleeping())
		{
			rollComplete = false;
		}

// making the counter work and making the game stop at 100 rolls
		if (rollComplete == true && mainCounter <100) {

 		mainCounter ++; 
		 Debug.Log (mainCounter);

		 if (mainCounter == 100) {
			 automateRoll = false;
		 }

		}
	}

}
