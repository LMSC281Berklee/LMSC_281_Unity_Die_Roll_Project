//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using UnityEngine.UI;

public class DisplayCurrentDieValue : MonoBehaviour
{
	public LayerMask dieValueColliderLayer = -1; 
	public GameObject canvas; 
	public Text[] results = new Text[6];

	private int currentValue = 1; 
	private GameController gameController; 
	private int[] allResults; 
	private int counter = 0; 
	private int[] resultsRatio = {0,0,0,0,0,0}; 
	private int resultInPercentage; 


	void Start()
	{
		
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null) 
		{
			gameController = gameControllerObject.GetComponent<GameController> ();
		}
		else
		{
			Debug.Log ("Cannot find 'GameController' Script");
		}

		allResults = new int[gameController.rolls];

		canvas.SetActive (false);

	}

	// Update is called once per frame
	void Update ()
	{
		
		RaycastHit hit;

		if(Physics.Raycast(transform.position,Vector3.up,out hit,Mathf.Infinity,dieValueColliderLayer))
		{
			currentValue = hit.collider.GetComponent<DieValue>().value;
		}

	}

	public void InsertResults()
	{
		allResults[counter] = currentValue;
		counter++; 
		WriteToAllResults (currentValue.ToString()); 
		if (counter < gameController.rolls)
		{ 
			WriteToAllResults (", ");
		} 
		else
		{
			WriteToAllResults (";\n"); 
		}

	}

	public void GetRatio()
	{ 
		for(int i=0; i<gameController.rolls; i++)
		{ 
			switch (allResults[i]){ 
			case 1:
				resultsRatio[0]++;
				break;
			case 2:
				resultsRatio[1]++;
				break;
			case 3:
				resultsRatio[2]++;
				break;
			case 4:
				resultsRatio[3]++;
				break;
			case 5:
				resultsRatio[4]++;
				break;
			case 6:
				resultsRatio[5]++;
				break;
			}
		}
		for (int i=0; i<6; i++) 
		{ 
			
			resultInPercentage = resultsRatio [i] * 100 / gameController.rolls; 
			results [i].text = resultsRatio [i].ToString () + "      (" + resultInPercentage.ToString () + "%)"; 
			WriteToResultsRatio (resultsRatio [i].ToString () + " (" + resultInPercentage.ToString () + "%)"); 

			if(i<5)
			{ 
				WriteToResultsRatio (", "); 
			}
		}
		WriteToResultsRatio (";\n"); 
		canvas.SetActive (true); 
	}

	//Copied from Jeanine Cowen's example
	public void WriteToAllResults (string myTextData) 
	{

		//the WriteAllText will delete any existing text from the file it is writing to
		//		File.WriteAllText ("Assets/Text/myNewTextFile",myTextData);

		//the AppendAllText will start writing to the file from wherever the last bit of data is found
		File.AppendAllText ("Assets/Text/AllResults.txt",myTextData);
	}

	//Copied from Jeanine Cowen's example
	public void WriteToResultsRatio(string myTextData) 
	{

		//the WriteAllText will delete any existing text from the file it is writing to
		//		File.WriteAllText ("Assets/Text/myNewTextFile",myTextData);

		//the AppendAllText will start writing to the file from wherever the last bit of data is found
		File.AppendAllText ("Assets/Text/ResultsRatio.txt",myTextData);
	}

}