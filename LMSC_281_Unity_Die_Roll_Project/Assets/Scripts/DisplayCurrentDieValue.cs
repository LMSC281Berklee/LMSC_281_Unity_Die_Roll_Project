//example provided by http://www.cookingwithunity.com/

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisplayCurrentDieValue : MonoBehaviour
{
	public LayerMask dieValueColliderLayer = -1;
	private int currentValue = 1;
	private bool rollComplete = false;

    public int[] DieValues = new int[100];
    public int arrayPosition = 0;
    public Text GameText;
    GameObject TextWriter;

    void Start()
    {
        TextWriter = GameObject.Find("TextHelper");
    }

    // Update is called once per frame
    void Update ()
	{
		RaycastHit hit;

		if(Physics.Raycast(transform.position,Vector3.up,out hit,Mathf.Infinity,dieValueColliderLayer))
		{
			currentValue = hit.collider.GetComponent<DieValue>().value;
		}

		if(GetComponent<Rigidbody>().IsSleeping() && !rollComplete)
		{
			rollComplete = true;
            GetComponent<ApplyForceInRandomDirection>().autoRun = true;
            CaptureToArray();
			//Debug.Log("Die roll complete, die is at rest");
		}
		else if(!GetComponent<Rigidbody>().IsSleeping())
		{
            rollComplete = false;
			GetComponent<ApplyForceInRandomDirection> ().autoRun = false;
		}
    }

    public void CaptureToArray ()
    {
        if (arrayPosition < DieValues.Length)
        {
            DieValues[arrayPosition] = currentValue;
            Debug.Log("Array Possition: " + arrayPosition + ", Value: " + DieValues[arrayPosition]);
            arrayPosition++;
        }

        if (arrayPosition == DieValues.Length)
        {
            GetComponent<ApplyForceInRandomDirection> ().autoRun = false;
            TextWriter.GetComponent<WriteToText>().runWriteArray = true;
            TextWriter.GetComponent<ReadArrayFromText>().readText = true;
            GameText.text = "Die Roll complete" + "\r\n" + "Press 'R' to reset Roll";
        }
    }

	void OnGUI()
	{
		GUILayout.Label(currentValue.ToString());
	}
}
