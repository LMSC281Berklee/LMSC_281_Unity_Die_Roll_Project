//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using System.IO;

public class DisplayCurrentDieValue : MonoBehaviour
{
    public LayerMask dieValueColliderLayer = -1;
    public GameObject canvas; //Stores the canvas to hide UI text
    public Text[] results = new Text[6];

    private int currentValue = 1; //declaration and placeholder for the currentValue in the GUI
    private GameController gameController; //to create a relationship with game controller script
    private int[] allResults; //int array to store all values
    private int counter = 0; //count the number of rolls to move along the array
    private int[] resultsRatio = { 0, 0, 0, 0, 0, 0 }; //array to store results ratio
    private int resultInPercentage; //to calculate the percentage of each value

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        } else
        {
            Debug.Log("Cannot find 'GameController' Script");
        }
        allResults = new int[gameController.rolls];
        canvas.SetActive(false);
    }

    public void InsertResults()
    { //called from ApplyForceInRandomDirection script
        allResults[counter] = currentValue; //insert current result to array
        counter++; //move to next location in the array
        WriteToAllResults(currentValue.ToString()); //write current value to file
        if (counter < gameController.rolls)
        { //if not last roll
            WriteToAllResults(", "); //write comma
        }
        else
        {
            WriteToAllResults(";\n"); //write semicolon and new line
        }

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.up, out hit, Mathf.Infinity, dieValueColliderLayer)) //if the raycast hits a collider, it returns the value
        {
            currentValue = hit.collider.GetComponent<DieValue>().value; //this is what makes it return the current value
        }
    }

    public void GetRatio()
    { //called from ApplyForceInRandomDirection script
        for (int i = 0; i < gameController.rolls; i++)
        { //go through all results in array
            switch (allResults[i])
            { //check for current element's value and add 1 to the right location in new array
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
        for (int i = 0; i < 6; i++)
        { //go over arary with ratio of results
            resultInPercentage = resultsRatio[i] * 100 / gameController.rolls; //calculate percentage comparing to number of rolls
            results[i].text = resultsRatio[i].ToString() + "      (" + resultInPercentage.ToString() + "%)"; //write to location on screen
            WriteToResultsRatio(resultsRatio[i].ToString() + " (" + resultInPercentage.ToString() + "%)"); //write to file
            if (i < 5)
            { //if note last one
                WriteToResultsRatio(", "); //write comma
            }
        }
        WriteToResultsRatio(";\n"); //write semicolon and new line
        canvas.SetActive(true); //activate canvas to show results
    }

    //Copied from Jeanine Cowen's example
    public void WriteToAllResults(string myTextData)
    {

        //the WriteAllText will delete any existing text from the file it is writing to
        //		File.WriteAllText ("Assets/Text/myNewTextFile",myTextData);

        //the AppendAllText will start writing to the file from wherever the last bit of data is found
        File.AppendAllText("Assets/Text/AllResults.txt", myTextData);
    }

    //Copied from Jeanine Cowen's example
    public void WriteToResultsRatio(string myTextData)
    {

        //the WriteAllText will delete any existing text from the file it is writing to
        //		File.WriteAllText ("Assets/Text/myNewTextFile",myTextData);

        //the AppendAllText will start writing to the file from wherever the last bit of data is found
        File.AppendAllText("Assets/Text/ResultsRatio.txt", myTextData);
    }
}
