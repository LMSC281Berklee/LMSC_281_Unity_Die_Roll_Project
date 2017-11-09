//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class SetMaxAngularVelocity : MonoBehaviour
{
	public float maxAngularVelocity = 7.0f;
    //When this is initated in game, this causes the die to move in an angle

	// Use this for initialization
	void Start ()
	{
		GetComponent<Rigidbody>().maxAngularVelocity = maxAngularVelocity;
        //Takes the RigidBody component and applies angular velocity
	}
}
//This is also attachedd directly to the die
