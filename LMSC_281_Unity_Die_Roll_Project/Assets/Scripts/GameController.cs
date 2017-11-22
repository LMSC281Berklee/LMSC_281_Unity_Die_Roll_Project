using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class GameController : MonoBehaviour {

	public int rolls; 
	public int timeScale; 

	// Use this for initialization
	void Start ()
	{
		Time.timeScale = timeScale; 
	}

	public void Restart()
	{ 
		Application.LoadLevel (Application.loadedLevel);
	}

	public void DeleteLogs() 
	{ 

		//the WriteAllText will delete any existing text from the file it is writing to
		File.WriteAllText ("Assets/Text/ResultsRatio.txt","");
		File.WriteAllText ("Assets/Text/AllResults.txt","");

	}
}