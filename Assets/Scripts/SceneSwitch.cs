using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public void GoToLevel1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GoToLevel2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void GoToLevel3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }

}
