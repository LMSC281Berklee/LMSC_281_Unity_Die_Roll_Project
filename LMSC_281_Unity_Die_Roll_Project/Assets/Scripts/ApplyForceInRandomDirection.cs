//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class ApplyForceInRandomDirection : MonoBehaviour
{
    public float forceAmount = 10.0f;
    //Declaration of what we'll call the force and its value
    public float torqueAmount = 10.0f;
    //Declaration of what we'll call the rotation and its value
    public ForceMode forceMode;
    //declaration of ForceMode. ForceMode gives an option on how to apply a force using RigidBody.AddForce which is used in the bool
    public LayerMask dieValueColliderLayer = -1;

    private int currentValue = -1;
    private bool rollComplete = false;
    private GameController gameController; //This is stated to link this to the corresponding script
    private DisplayCurrentDieValue displayCurrentValue; //This is stated to link this to the corresponding script


    private void Start()
    //Create relationship with GameController script
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Cannot Find 'GameController' Script");
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

        if (GetComponent<Rigidbody>().IsSleeping() && !rollComplete) //IsSleeping refers to if the object is at rest and not moving, and if it is, the roll is finished.
        {
            rollComplete = true;
            Debug.Log("Die roll complete, die is at rest");
            //This is to debug to notify that the die is no longer moving so the score could be counted and verified
        }
        else if (!GetComponent<Rigidbody>().IsSleeping()) //When the roll is not complete, there will not be debug info in the console
        {
            rollComplete = false;
        }
    }


    IEnumerator StartRolling()
        {
            yield return new WaitForSeconds(1); //wait for 1 second
            for (int i = 0; i < gameController.rolls; i++)
            { //repeat the number of times set in GameController script 
                yield return new WaitForSeconds(3); //wait for three seconds (let the current roll end)
                displayCurrentValue.InsertResults(); //call a function in DisplayCurrentValue to store result
            }
            displayCurrentValue.GetRatio(); //call a function in DisplayCurrentValue to calculate and show ratio
        }
    void OnGUI()
    {
        GUILayout.Label(currentValue.ToString()); //this is a script to display the currentValue of the counter
    }
}

//This is attached directly onto the die