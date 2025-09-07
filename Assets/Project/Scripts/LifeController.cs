using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeController : MonoBehaviour
{
    [Header("Impostazioni Vite")]
    public int maxLives = 3;
    private int currentLives;

    [Header("UI Cuori")]
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    [Header("Player e Respawn")]
    public Transform player;
    public Transform respawnPoint;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip loseLifeClip;
    public AudioClip extraLifeClip;   
    public AudioClip defeatClip;      

    [Header("Game Over")]
    public GameObject gameOverCanvas;

    private bool isRespawning = false;

    void Start()
    {
        currentLives = maxLives;
        UpdateHeartsUI();
    }

    public void LoseLife()
    {
        if (currentLives <= 0 || isRespawning) return;

        currentLives--;
        UpdateHeartsUI();

        if (loseLifeClip != null && audioSource != null)
            audioSource.PlayOneShot(loseLifeClip);

        if (currentLives <= 0)
        {
            GameOver();
        }
        else
        {
            StartCoroutine(RespawnCoroutine());
        }
    }

    public void AddLife()
    {
        if (currentLives < maxLives)
        {
            currentLives++;
            UpdateHeartsUI();

            if (extraLifeClip != null && audioSource != null)
                audioSource.PlayOneShot(extraLifeClip);
        }
    }

    IEnumerator RespawnCoroutine()
    {
        isRespawning = true;

        if (player != null)
            player.gameObject.SetActive(false);

        yield return new WaitForSeconds(3f);

        if (player != null && respawnPoint != null)
        {
            player.transform.position = respawnPoint.position;
            player.gameObject.SetActive(true);
        }

        isRespawning = false;
    }

    void UpdateHeartsUI()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = i < currentLives ? fullHeart : emptyHeart;
        }
    }

    void GameOver()
    {

        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(true);

        if (defeatClip != null && audioSource != null)
            audioSource.PlayOneShot(defeatClip);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoseLife();
        }

        if (other.CompareTag("Life"))
        {
            AddLife();
            Destroy(other.gameObject);
        }
    }
}
