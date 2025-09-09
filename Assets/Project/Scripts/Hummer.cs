using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hummer : MonoBehaviour
{
    [SerializeField] private float swingAngle = 45f; // Angolo massimo di oscillazione
    [SerializeField] private float swingSpeed = 2f;      
    [SerializeField] private float pushMultiplier = 2f;   // Quanto forte spinge
    private Quaternion startRotation;
    private Vector3 lastPos;

    void Start()
    {
        startRotation = transform.localRotation;
        lastPos = transform.position;
    }

    void Update()
    {
        // Oscillazione come progetto precedente con Mathf.Sin
        float angle = Mathf.Sin(Time.time * swingSpeed) * swingAngle;
        transform.localRotation = startRotation * Quaternion.Euler(0f, 0f, angle);
    }

    void LateUpdate()
    {
        lastPos = transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 hammerVelocity = (transform.position - lastPos) / Time.deltaTime;
                rb.AddForce(hammerVelocity * pushMultiplier, ForceMode.Impulse);
            }
        }
    }
}
