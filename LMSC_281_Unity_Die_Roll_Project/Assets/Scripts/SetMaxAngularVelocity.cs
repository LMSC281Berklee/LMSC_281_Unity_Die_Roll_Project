//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class SetMaxAngularVelocity : MonoBehaviour
{
	public float maxAngularVelocity = 7.0f; // variable with a value for the limit of rotation

	// Use this for initialization
	void Start ()
	{
		// this sets a limit to the rotation of the die so it doesnt spin out of control
		GetComponent<Rigidbody>().maxAngularVelocity = maxAngularVelocity;
	}
}
