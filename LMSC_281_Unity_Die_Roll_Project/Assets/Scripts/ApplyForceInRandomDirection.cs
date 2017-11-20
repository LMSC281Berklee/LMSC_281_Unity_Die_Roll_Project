//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;

public class ApplyForceInRandomDirection : MonoBehaviour
{
	public string buttonName = "Fire1";
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
    public int numOfRolls = 100;
    public int[] valOfRolls = new int[100]; 
    public bool automateRoll;
	public ForceMode forceMode;

    void Start()
    {
        automateRoll = false;    
    }
    // Update is called once per frame
    void Update ()
	{
        if (Input.GetButtonDown(buttonName))
        {
            while (numOfRolls > 0)
            {
                GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * forceAmount, forceMode);
                GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere * torqueAmount, forceMode);
                Debug.Log("1 roll down");
                numOfRolls--;
            }
        }
	}
}
