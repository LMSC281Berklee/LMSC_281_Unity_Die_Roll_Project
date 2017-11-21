using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{


    public int rolls;
    public int timeScale;

    void Start()
    {
        Time.timeScale = timeScale; //This is for setting the time scale
    }

    public void Restart()
    {
        SceneManager.GetActiveScene();
    }

    public void NewLogs() //This is to clear the reults text file every game
    {
        File.WriteAllText("Assets/Text/Results.txt", "");
        File.WriteAllText("Assets/Text/AllResults.txt", "");
    }
}