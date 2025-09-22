using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DoubleShotTurret : MonoBehaviour
{
    public Transform[] firePoints; 
    public float fireRate = 1f;
    private float fireTimer;

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer >= 1f / fireRate)
            {
                Shoot();
                fireTimer = 0f;
            }
        }
    }

    void Shoot()
    {
        foreach (var fp in firePoints)
        {
            PoolManager.Instance.SpawnFromPool("Bullet", fp.position, fp.rotation);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) playerInRange = true;
        Shoot();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) playerInRange = false;
    }
}

