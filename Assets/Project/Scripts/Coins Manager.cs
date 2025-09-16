using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private int maxCoins = 10;
    public int totalCoins = 0;

    public static CoinsManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        UpdateUI();
    }

    public void AddCoins(int value)
    {
        totalCoins += value;
        UpdateUI();
    }
    public void UpdateUI()
    {
        coinsText.text = "Coins " + totalCoins + "/ " + maxCoins;
    }
   
}
