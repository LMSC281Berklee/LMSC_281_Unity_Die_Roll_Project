//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class DisplayCurrentDieValue : MonoBehaviour
{
	public LayerMask dieValueColliderLayer = -1;

	private int currentValue = 1;

	private bool rollComplete = false;

	// Update is called once per frame
	void Update ()
	{

		/*this script is bascially calulating where the die is and stating that 
		if the die is resting then we should display the numeric value associated with 
		the face of the die */
		RaycastHit hit;

		if(Physics.Raycast(transform.position,Vector3.up,out hit,Mathf.Infinity,dieValueColliderLayer))
		{
			currentValue = hit.collider.GetComponent<DieValue>().value;
		}

		if(GetComponent<Rigidbody>().IsSleeping() && !rollComplete)
		{
			rollComplete = true;
			Debug.Log("Die roll complete, die is at rest");
		}
		else if(!GetComponent<Rigidbody>().IsSleeping())
		{
			rollComplete = false;
		}
	}

	void OnGUI()
	{
		GUILayout.Label(currentValue.ToString());
	}
}
