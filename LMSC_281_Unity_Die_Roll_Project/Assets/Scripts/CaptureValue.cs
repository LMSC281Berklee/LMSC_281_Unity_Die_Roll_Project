using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaptureValue : MonoBehaviour {

	//an array to hold all of our values
	int[] allRolls = new int[100];

	int arrayPosition = 0;
	//holds the value received from the game
	public int currentNumber = 1;

	public Text results;


	// Use this for initialization
	void Start () {
		//CaptureToArray ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CaptureToArray () {
		//check to ensure the array position is valid
		if (arrayPosition < allRolls.Length) {
			allRolls [arrayPosition] = currentNumber;
			Debug.Log ("The current array position is " + arrayPosition + " with a value of " + allRolls [arrayPosition]);
			arrayPosition++;
		}
	}


	//JC to display the results to the gamewindow we need to convert the array into a string and then send to a text object
	public void DisplayResults ()
		{
		results.text = "The results are as follows:" + "\n";
		for (int i = 0; i < allRolls.Length; i++) {
			results.text = results.text + allRolls [i].ToString () + " , ";
		}

}
}