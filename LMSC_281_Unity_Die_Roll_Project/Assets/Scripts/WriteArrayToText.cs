//Kellen Fenton
//Fall 2017
//Logic and Programming
//using Jeanine Cowens walkthrough 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WriteArrayToText : MonoBehaviour {
	public LayerMask dieValueColliderLayer = -1;




	
	//identifying the file we will be writing to 
	string fileToWriteTo;
	public string stringOfValues; 
	public bool runwriteArray = false;
	// private DisplayCurrentDieValue DisplayCurrentDieValue;
	private int currentValue = 1;
	


	GameObject playerObject; 
	

	// Use this for initialization
	void Start () {
		
	
		
		//identifies the folder we're writing to
		fileToWriteTo = Application.dataPath + "/Resources/Data.txt";

		// playerObject = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	
	
	void Update () {
 
   
//         for (int i = 0; i < Die.GetComponent<currentValue>().dieNumberArray.Length; i++)
//         {
//         int intArrayValue = Die.GetComponent<currentValue>().dieNumberArray[i];
//             stringOfValues = stringOfValues + intArrayValue.ToString();
//         }



		
		if(GetComponent<Rigidbody>().IsSleeping()) { 	
		runwriteArray = true;
	}
		
		
		if (runwriteArray) {
			WriteArray ();
			runwriteArray = false;
	
		
		}
		
		stringOfValues = currentValue.ToString();
		RaycastHit hit;

		if(Physics.Raycast(transform.position,Vector3.up,out hit,Mathf.Infinity,dieValueColliderLayer))
		{
			currentValue = hit.collider.GetComponent<DieValue>().value;
		}
	}
			
	void OnGUI()
	{
		GUILayout.Label(currentValue.ToString());
	}


	
	public void WriteArray () {
		
		//write data out to a text file
		File.AppendAllText( fileToWriteTo, stringOfValues);

	}
}


