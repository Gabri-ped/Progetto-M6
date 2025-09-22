using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FanTurret : MonoBehaviour
{
    public Transform firePoint;
    public float fireRate = 1f;
    public float angleStep = 15f; 
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
        float startAngle = -2 * angleStep;
        for (int i = 0; i < 5; i++)
        {
            Quaternion rot = firePoint.rotation * Quaternion.Euler(0, startAngle + (i * angleStep), 0);
            PoolManager.Instance.SpawnFromPool("Bullet", firePoint.position, rot);
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

