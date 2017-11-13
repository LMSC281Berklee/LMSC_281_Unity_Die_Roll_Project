//example provided by http://www.cookingwithunity.com/


//I am doing another change right here as a test.
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayCurrentDieValue : MonoBehaviour
{
	public LayerMask dieValueColliderLayer = -1;

	private int currentValue = 1;

	private bool rollComplete = false;

	public Text results;

	// Update is called once per frame
	void Update ()
	{
		RaycastHit hit;

		if(Physics.Raycast(transform.position,Vector3.up,out hit,Mathf.Infinity,dieValueColliderLayer))
		{
			currentValue = hit.collider.GetComponent<DieValue>().value;
			if (GetComponent<ApplyForceInRandomDirection> ().rollTheDie) 
			{
				GetComponent<CaptureValue> ().currentNumber = hit.collider.GetComponent<DieValue> ().value;
				GetComponent<CaptureValue> ().CaptureToArray ();
				GetComponent<ApplyForceInRandomDirection>().rollCount++;
				GetComponent<ApplyForceInRandomDirection>().CheckCount();

			}
		}

		if(GetComponent<Rigidbody>().IsSleeping() && !rollComplete)
		{
			rollComplete = true;
			Debug.Log("Die roll complete, die is at rest");
			GetComponent<CaptureValue>().DisplayResults();
		}
		else if(!GetComponent<Rigidbody>().IsSleeping())
		{
			rollComplete = false;
		}


	}

	void OnGUI()
	{
		GUILayout.Label (currentValue.ToString ());
	}
}
