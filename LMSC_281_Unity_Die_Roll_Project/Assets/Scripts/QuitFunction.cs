using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitFunction : MonoBehaviour {

    public void QuitButton()
    {
        Debug.Log("The Game has been terminated");
        Application.Quit();
    }
}
