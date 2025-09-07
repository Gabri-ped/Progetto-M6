using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;

public class CoinsManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;

    public static CoinsManager instance;

    public int totalCoins = 0;


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

    public void AddCoins(int amount)
    {
        totalCoins += amount;
        
    }
    public void UpdateUI()
    {
        coinsText.text = "Coins " + totalCoins.ToString();
    }

}
