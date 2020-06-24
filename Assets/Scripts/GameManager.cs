using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameHasComplete = false;
    public bool gameHasEnded = false;
    float restartDelay = 1f;

    public GameObject completeLevelUI;
    public GameObject failtLevelUI;

    public void CompleteLevel()
    {
        if(gameHasComplete == true && gameHasEnded == false) 
        {
            completeLevelUI.SetActive(true);
        }
    }
    public void Fail()
    {
        failtLevelUI.SetActive(true);
    }
    public void FailLevel()
    {
        if(gameHasEnded == true && gameHasComplete == false)
        {
            Invoke("Fail", restartDelay);
            Debug.Log("Game Over");
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
