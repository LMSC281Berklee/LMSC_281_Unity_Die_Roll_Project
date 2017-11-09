//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class ApplyForceInRandomDirection : MonoBehaviour
{
	public string buttonName = "r";
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
	public ForceMode forceMode;

	public bool automateRoll = false;

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown(buttonName))
		{
			automateRoll = true;
		}

		if (automateRoll)
		{
			GetComponent<Rigidbody>().AddForce(Random.onUnitSphere*forceAmount,forceMode);
			GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere*torqueAmount,forceMode);
			automateRoll = false;
		}
	}
}
