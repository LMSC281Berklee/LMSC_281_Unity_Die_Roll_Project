//Lawrence Delloye
//LMSC 281
//Fall 2017

//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class ApplyForceInRandomDirection : MonoBehaviour
{
    //Variables
    //public string buttonName = "Fire1";

    public float forceAmount = 10.0f;
    public float torqueAmount = 10.0f;
    public bool automateRoll;
	public ForceMode forceMode;
    //Speed up Die Automation
    public float timeSpeed = 5.0F;

    void Start()
    {
        automateRoll = false;
        Time.timeScale = timeSpeed;
    }
    // Update is called once per frame
    void Update ()
	{
        if (automateRoll)
        {
             GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * forceAmount, forceMode);
             GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere * torqueAmount, forceMode);
        }
	}
}
