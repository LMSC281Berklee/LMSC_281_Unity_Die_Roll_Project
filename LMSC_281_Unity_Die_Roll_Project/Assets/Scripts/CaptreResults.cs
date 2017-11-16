using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptreResults : MonoBehaviour
{
    int[] DieValues = new int[100];
    int arrayPosition = 0;

    public void CaptureValues ()
    {
        if (arrayPosition < DieValues.Length)
        {
            Debug.Log("Current value = " + DieValues[arrayPosition] + ",   Array Number = " + arrayPosition);
            arrayPosition++;
        }
    }
}
