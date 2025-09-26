using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenùManager : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene(1);
        AudioManager.Instance.PlayMusic(AudioManager.Instance.backgroundMusic);
        Time.timeScale = 1f;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        AudioManager.Instance.StopVictorySound();
    }
}
