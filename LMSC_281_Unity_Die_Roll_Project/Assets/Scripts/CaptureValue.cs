using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureValue : MonoBehaviour {

	//an array to hold all of our values
	int[] allScores = new int[100];

	int arrayPosition = 0;
	//holds the value received from the game
	public int currentNumber = 1;


	// Use this for initialization
	void Start () {
		CaptureToArray ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CaptureToArray () {
		//check to ensure the array position is valid
		if (arrayPosition < allScores.Length) {
			allScores [arrayPosition] = currentNumber;
			Debug.Log ("The current array position is " + arrayPosition + " with a value of " + allScores [arrayPosition]);
			arrayPosition++;
		}
	}
}
