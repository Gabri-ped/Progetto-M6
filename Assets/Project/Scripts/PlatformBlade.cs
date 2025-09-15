using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBlade : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            LifeController.instance.LoseLife();
        }
    }
}
