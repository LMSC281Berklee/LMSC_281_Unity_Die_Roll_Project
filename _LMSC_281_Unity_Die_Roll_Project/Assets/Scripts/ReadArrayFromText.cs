//LMSC 281
//Augustus Rivera
//Reading integer data back into an array

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//library to include file operations
using System.IO;

public class NewBehaviourScript : MonoBehaviour {

	//variable to hold string data coming from the txt file
	string allTextString;

	//boolean uses to trigger readtext function
	public bool readText = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (readText) {
			ReadTextFromFile ();
			readText = false;
		}
		
	}

	public void ReadTextFromFile () {
		//assign text back into our string
		allTextString = File.ReadAllText (Application.dataPath + "/Resources/Data.txt");
		Debug.Log (allTextString);
	}
}
