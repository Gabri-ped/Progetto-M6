using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int coinValue = 1;
    public float speed = 3f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinsManager.instance.AddCoins(coinValue);
            Destroy(gameObject); 
        }
    }
    void Update()
    {
        transform.Rotate(0f, speed, 0f * Time.deltaTime / 0.01f, Space.Self);
    }
}
