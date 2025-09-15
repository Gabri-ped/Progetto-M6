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

    [Header("Game Over")]
    public GameObject gameOverCanvas;

    private bool isRespawning = false;
    public static LifeController instance;

    void Start()
    {
        instance = this;
        currentLives = maxLives;
        UpdateHeartsUI();
    }

    public void LoseLife()
    {
        currentLives--;
        UpdateHeartsUI();

        if (currentLives > 0)
        {
            StartCoroutine(RespawnCoroutine());
        }
        else
        {
            GameOver();
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
            AudioManager.Instance.PlayLoseSound();
    }
}
