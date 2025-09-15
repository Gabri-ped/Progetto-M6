using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RotateBlade : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAxis = Vector3.up; // Asse di rotazione (default Y)
    [SerializeField] private float rotationSpeed = 200f;        // Velocità di rotazione

    void Update()
    {
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LifeController.instance?.LoseLife();
        }
    }
}
