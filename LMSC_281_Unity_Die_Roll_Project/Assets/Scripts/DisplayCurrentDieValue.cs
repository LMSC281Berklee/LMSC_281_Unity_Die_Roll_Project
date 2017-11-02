//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class DisplayCurrentDieValue : MonoBehaviour	// class that displays the current die value every time it is rolled
{
	public LayerMask dieValueColliderLayer = -1;

	private int currentValue = 1;		// integer value to store the current value of the die

	private bool rollComplete = false;	// boolean value for if the roll is complete or not

	// Update is called once per frame
	void Update ()
	{
		RaycastHit hit;
		
		// this the code that figures out what side of the die is showing
		if(Physics.Raycast(transform.position,Vector3.up,out hit,Mathf.Infinity,dieValueColliderLayer))
		{
			// gets a value to be stored in the DieValue variable
			currentValue = hit.collider.GetComponent<DieValue>().value;
		}
		
		// this is so that the program knows when the die is finished its roll and then it can display to the console
		if(GetComponent<Rigidbody>().IsSleeping() && !rollComplete)
		{
			rollComplete = true;
			Debug.Log("Die roll complete, die is at rest"); // output to console for when the roll is complete
		}
		else if(!GetComponent<Rigidbody>().IsSleeping())
		{
			rollComplete = false;	// this sets rollComplete back to false for the next roll
		}
	}

	void OnGUI()
	{
		GUILayout.Label(currentValue.ToString());
	}
}
