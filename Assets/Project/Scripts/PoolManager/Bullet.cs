using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;
    public string poolTag;

    private void OnEnable() => Invoke(nameof(ReturnToPool), lifeTime);
    private void OnDisable() => CancelInvoke();

    void Update() => transform.Translate(Vector3.forward * speed * Time.deltaTime);

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

