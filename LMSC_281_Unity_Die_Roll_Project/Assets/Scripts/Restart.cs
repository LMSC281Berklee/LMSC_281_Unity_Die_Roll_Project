using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
	
	// Update is called once per frame
	public void Reset() {
		SceneManager.LoadScene ("DiceRoller3d");
	
		
	}
}
