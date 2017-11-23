using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WriteToText : MonoBehaviour
{
    string FileToWriteTo;
    public string StringOfValues;
    public bool runWriteArray = false;

    GameObject playerObject;

	// Use this for initialization
	void Start ()
    {
        //File.WriteAllText("/Resources/Data.txt", string.Empty);
        FileToWriteTo = Application.dataPath + "/Resources/Data.txt";
        playerObject = GameObject.Find("Die");
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (runWriteArray)
        {
            WriteArray();
            runWriteArray = false;
        }
	}

    public void WriteArray ()
    {
        for (int i = 0; i < playerObject.GetComponent<DisplayCurrentDieValue>().DieValues.Length; i++)
        {
            int intArrayValue = playerObject.GetComponent<DisplayCurrentDieValue>().DieValues[i];
            StringOfValues = StringOfValues + intArrayValue.ToString();
        }

        StringOfValues = StringOfValues + "\r\n";
        File.WriteAllText(FileToWriteTo, StringOfValues);
    }
}
