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

    public bool autoRun = false;
    public float timeSpeed = 1.0f;

    void Start()
    {
        Time.timeScale = 1.0f * timeSpeed;
    }

    // Update is called once per frame
    void Update ()
	{
         if (autoRun)
        {
            GetComponent<Rigidbody>().AddForce(Random.onUnitSphere * forceAmount, forceMode);
            GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere * torqueAmount, forceMode);
        }
    }
}
