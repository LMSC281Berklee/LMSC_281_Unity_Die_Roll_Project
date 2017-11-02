//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class ApplyForceInRandomDirection : MonoBehaviour
{
	//getting input from the mouse click 1 (called Fire1)
	public string buttonName = "Fire1";
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
	public ForceMode forceMode;

	// Update is called once per frame
	void Update ()
	{
		//get mouse click
		if(Input.GetButtonDown(buttonName)) 
		{
		//applying a random force
			GetComponent<Rigidbody>().AddForce(Random.onUnitSphere*forceAmount,forceMode);
			GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere*torqueAmount,forceMode);
		}
	}
}
