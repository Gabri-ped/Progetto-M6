using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    [SerializeField] private GameObject _canvas;

    void Start()
    {
        _canvas.SetActive(false);
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LifeController.instance?.LoseLife();
            AudioManager.Instance.PlayLoseSound();
            _canvas.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
