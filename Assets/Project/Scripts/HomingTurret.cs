using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingTurret : MonoBehaviour
{
    public Transform firePoint;
    public float fireRate = 2f;
    private float fireTimer;

    private bool playerInRange = false;
    private Transform player; 

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
        if (player == null) return;
        GameObject bulletObj = PoolManager.Instance.SpawnFromPool("HomingBullet", firePoint.position, firePoint.rotation);
        bulletObj.GetComponent<HomingBullet>().SetTarget(player);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            player = other.transform;
            Shoot();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            player = null;
        }
    }
}
