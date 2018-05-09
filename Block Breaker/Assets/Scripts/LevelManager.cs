using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        Brick.breakableCount = 0;
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Want to Quit!!!");
        Application.Quit();  
    }

    public void LoadNextLevel()
    {
        Brick.breakableCount = 0;
        Application.LoadLevel(Application.loadedLevel + 1);
    }

    public void BrickDestroyed()
    {
        // if the last brick was destroyed
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
            print("The last brick was destroyed");
        }
    }
}
