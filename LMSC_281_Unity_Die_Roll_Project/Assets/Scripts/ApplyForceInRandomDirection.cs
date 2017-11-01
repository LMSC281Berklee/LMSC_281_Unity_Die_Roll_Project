//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class ApplyForceInRandomDirection : MonoBehaviour	// publuc class that's called when the die needs to be rolled
{
	public string buttonName = "Fire1";	// string variable for the input trigger to roll the die
	public float forceAmount = 10.0f;	// a value to multiply the force of the die movment
	public float torqueAmount = 10.0f;	// a value to multiply the torque of the die movment
	public ForceMode forceMode;

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown(buttonName)) // if the button is triggered then these forces are applied
		{
			// applies a random force to the die
			GetComponent<Rigidbody>().AddForce(Random.onUnitSphere*forceAmount,forceMode);
			// applies a random torque to the die so it can turn in a random direction
			GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere*torqueAmount,forceMode);
		}
	}
}
