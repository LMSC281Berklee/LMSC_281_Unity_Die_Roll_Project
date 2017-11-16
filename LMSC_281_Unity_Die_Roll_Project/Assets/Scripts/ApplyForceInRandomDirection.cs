//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ApplyForceInRandomDirection : MonoBehaviour
{
	public string buttonName = "Fire1";
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
	public ForceMode forceMode;

    public bool rollTheDie = false;
    public int rollCount = 0;
    public Text startText;

    // Update is called once per frame
    void Update ()
	{
        if (Input.GetButtonDown (buttonName))
		{
            rollTheDie = true;
            startText.text = "Press 'R' to reset Die Roll";
        }

        if (GetComponent<Rigidbody>().IsSleeping() && rollTheDie)
        {
            GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * forceAmount, forceMode);
            GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere * torqueAmount, forceMode);
        }
    }

    public void Count()
    {
        if (rollCount < 4)
        {
            Debug.Log("Roll Number: " + rollCount);
            rollCount++;
        }
        else if (rollCount >= 4)
        {
            rollTheDie = false;
        }
    }
}
