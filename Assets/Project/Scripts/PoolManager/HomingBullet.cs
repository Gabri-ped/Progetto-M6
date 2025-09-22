using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    public float speed = 7f;
    public float rotateSpeed = 200f;
    public float lifeTime = 4f;
    public string poolTag;

    private Transform target;

    public void SetTarget(Transform player)
    {
        target = player;
        CancelInvoke();
        Invoke(nameof(ReturnToPool), lifeTime);
    }

    void Update()
    {
        if (target == null) return;

        Vector3 direction = (target.position - transform.position).normalized;
        float rotateAmount = Vector3.Cross(transform.forward, direction).y;

        transform.Rotate(0, rotateAmount * rotateSpeed * Time.deltaTime, 0);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LifeController.instance.LoseLife();
            ReturnToPool();
        }
    }

    void ReturnToPool() => PoolManager.Instance.ReturnToPool(poolTag, gameObject);
}

