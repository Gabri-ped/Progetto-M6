using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;  
    public AudioSource sfxSource;     
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] public AudioClip backgroundMusic;
    [SerializeField] private AudioClip coinSound;
    [SerializeField] private AudioClip winSound;
    [SerializeField] private AudioClip loseSound;
    [SerializeField] private AudioClip buttonSound;
    [SerializeField] private AudioClip bombSound;

    public static AudioManager Instance;

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); 
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0) 
            PlayMusic(menuMusic);

        else if (scene.buildIndex == 1) 
            PlayMusic(backgroundMusic);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip != null)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        if (musicSource.isPlaying)
            musicSource.Stop();
    }
    public void PlayCoinSound()
    {
        if (coinSound != null)
            sfxSource.PlayOneShot(coinSound);
    }

    public void PlayWinSound()
    {
        StopBackgroundMusic();
        if (winSound != null)
            sfxSource.PlayOneShot(winSound);
    }

    public void PlayLoseSound()
    {
        StopBackgroundMusic();
        if (loseSound != null)
            sfxSource.PlayOneShot(loseSound);
    }

    public void PlayButtonSound()
    {
        if (buttonSound != null)
            sfxSource.PlayOneShot(buttonSound);
    }
    public void PlayBombSound()
    {
        if (loseSound != null)
            sfxSource.PlayOneShot(bombSound);
    }
}

