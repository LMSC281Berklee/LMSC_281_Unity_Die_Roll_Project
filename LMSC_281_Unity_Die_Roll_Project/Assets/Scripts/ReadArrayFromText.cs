﻿//Conrad Robertson
//LMSC-281
//Fall 2016
//Die Roll Project

using UnityEngine;
using System.Collections;
//library to include file operations
using System.IO;

public class ReadArrayFromText : MonoBehaviour {

	// variable to hold the string data coming from the text file
	string allTextString;

	//boolean used to trigger ReadTextFromFile
	public bool readText = false;

	public int[] intArray = new int[100];


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

		//assign all text into our string
		allTextString = File.ReadAllText(Application.dataPath + "/Resources/Data.txt");
		Debug.Log (allTextString);

		for (int i = 0; i < 100; i++) {
			string tempString = allTextString[i].ToString();

			intArray [i] = System.Int32.Parse (tempString);


			}
		}

	
}
