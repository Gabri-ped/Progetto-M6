using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenùManager : MonoBehaviour
{
   public void NewGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void LoadGame()
    {

    }
    public void Settings()
    {
        SceneManager.LoadScene(2);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
