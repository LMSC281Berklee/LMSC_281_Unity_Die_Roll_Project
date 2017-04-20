//LMSC 281
//Augustus Rivera
//Allow player to restart game

//JC applied this script to the main camera so that it will be active when the game starts
//and renamed to player controls so that it can hold the write to array checkbox

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour {

	//JC let the player determine when the data is written to the file
	bool writeToFile = false;
	public WriteArrayToText writeFunction;

	void OnGUI (){
		if (GUI.Button (new Rect (20f, 200f, 100, 50), new GUIContent ("Restart"))) {
			SceneManager.LoadScene ("DiceRoller3d");
		}

		//JC add ability for the user to select to write out to the text file
		if (GUI.Toggle (new Rect (20f, 150f, 100, 50), writeToFile, "Write Data?")) {
			writeFunction.runWriteArray = true;
		}
	}
}

