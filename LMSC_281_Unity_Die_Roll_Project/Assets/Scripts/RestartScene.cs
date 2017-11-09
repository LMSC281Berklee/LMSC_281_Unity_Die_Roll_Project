using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour {

    public void RestartGame()
    {
        //loads current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log ("The game has restarted");
        }
}