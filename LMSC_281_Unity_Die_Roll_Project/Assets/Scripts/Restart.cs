using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
		
	}

    public void RestartButton()
    {
        //This will load the active scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
