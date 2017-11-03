//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class SetMaxAngularVelocity : MonoBehaviour
{
	//this is making sure that the die doesn't just go straight up 
	public float maxAngularVelocity = 10.0f;

	// Use this for initialization
	void Start ()
	{
		GetComponent<Rigidbody>().maxAngularVelocity = maxAngularVelocity;
	}
}
