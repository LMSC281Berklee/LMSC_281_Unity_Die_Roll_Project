//LMSC 281
//Augustus Rivera
//Allow player to restart game

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerRestart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI (){
		if (GUI.Button (new Rect (20f, 200f, 100, 100), new GUIContent ("Restart"))) {
			SceneManager.LoadScene ("DiceRoller3d");
		}
	}
}

