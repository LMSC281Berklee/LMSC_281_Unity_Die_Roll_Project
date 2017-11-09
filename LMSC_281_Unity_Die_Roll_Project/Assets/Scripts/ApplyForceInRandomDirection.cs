//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class ApplyForceInRandomDirection : MonoBehaviour
{
	public string buttonName = "Fire1";
    //declaration of what we'll call it when the mouse is clicked
	public float forceAmount = 10.0f;
    //Declaration of what we'll call the force and its value
	public float torqueAmount = 10.0f;
    //Declaration of what we'll call the rotation and its value
	public ForceMode forceMode;
    //declaration of ForceMode. ForceMode gives an option on how to apply a force using RigidBody.AddForce which is used in the bool

	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown(buttonName))
        //This means if the mouse is clicked
		{
			GetComponent<Rigidbody>().AddForce(Random.onUnitSphere*forceAmount,forceMode);
            //Get the RigidBody that's attached to the gameObject and apply the force onto it
			GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere*torqueAmount,forceMode);
            //Get the RigidBody that's attached to the gameObject and apply the rotation onto it
		}
	}
}
//This is attached directly onto the die