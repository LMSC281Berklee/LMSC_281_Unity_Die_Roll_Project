//LMSC 281
//Augustus Rivera


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//include library for file funcitons
using System.IO;

public class WriteArrayToText : MonoBehaviour {

	//identify the file to write to at runtime
 	string fileToWriteTo;

	public string stringOfValues;
	public bool runWriteArray = false;

	//to store "100" value to be referenced
	public int[] readText = new int[100];

	GameObject playerObject;


	// Use this for initialization
	void Start () {

		//to test we will inititialize the stringOfValues
		//stringOfValues = "test text";


		//write to folder where project is located, specifically in the "resources" folder
		fileToWriteTo= Application.dataPath + "/Resources/Data.txt";

		playerObject = GameObject.Find ("Die");
		
	}
	
	// Update is called once per frame
	void Update () {
		if (runWriteArray) {
			WriteArray ();
			runWriteArray = false;
		}
	}

	public void WriteArray () {
		for (int i = 0; i < playerObject.GetComponent<DisplayCurrentDieValue> ().dieResults.Length; i++) {
			int intArrayValue = playerObject.GetComponent<DisplayCurrentDieValue>().dieResults[i];
			stringOfValues = stringOfValues + intArrayValue.ToString ();
		}

		stringOfValues = stringOfValues + "\r\n";

		//use append to write data to txt file
		File.AppendAllText (fileToWriteTo, stringOfValues);

		//overwrite info in txt file
		File.WriteAllText  (fileToWriteTo, stringOfValues);
	}
		 
		
}