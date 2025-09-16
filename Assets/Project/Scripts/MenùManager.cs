using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenùManager : MonoBehaviour
{
    [SerializeField] private AudioSource maxAudio;
    [SerializeField] private AudioClip _buttonSound;

    public void PlayButtonSound()
    {
        maxAudio.PlayOneShot(_buttonSound);
    }

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
        SaveSystem.Instance.LoadGame();
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
