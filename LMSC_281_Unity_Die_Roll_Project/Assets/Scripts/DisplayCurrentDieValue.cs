//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class DisplayCurrentDieValue : MonoBehaviour
{
	public LayerMask dieValueColliderLayer = -1;

	private int currentValue = 1; //declaration and placeholder for the currentValue in the GUI

	private bool rollComplete = false;
    //This is private so the condition cannot be altered

	// Update is called once per frame
	void Update ()
	{
		RaycastHit hit;

		if(Physics.Raycast(transform.position,Vector3.up,out hit,Mathf.Infinity,dieValueColliderLayer)) //if the raycast hits a collider, it returns the value
		{
			currentValue = hit.collider.GetComponent<DieValue>().value; //this is what makes it return the current value
		}

		if(GetComponent<Rigidbody>().IsSleeping() && !rollComplete) //IsSleeping refers to if the object is at rest and not moving, and if it is, the roll is finished.
		{
			rollComplete = true;
			Debug.Log("Die roll complete, die is at rest");
            //This is to debug to notify that the die is no longer moving so the score could be counted and verified
		}
		else if(!GetComponent<Rigidbody>().IsSleeping()) //When the roll is not complete, there will not be debug info in the console
		{
			rollComplete = false;
		}
	}

	void OnGUI()
	{
		GUILayout.Label(currentValue.ToString()); //this is a script to display the currentValue of the counter
	}
}
