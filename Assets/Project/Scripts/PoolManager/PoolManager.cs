using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Pool
{
    public string tag;
    public GameObject prefab;
    public int size;
}
public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    [SerializeField] private List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(true);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Pool con tag " + tag + " non esiste!");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Count > 0 ? poolDictionary[tag].Dequeue() : Instantiate(GetPrefab(tag));
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        return objectToSpawn;
    }

    public void ReturnToPool(string tag, GameObject obj)
    {
        obj.SetActive(false);
        poolDictionary[tag].Enqueue(obj);
    }

    private GameObject GetPrefab(string tag)
    {
        foreach (Pool pool in pools)
        {
            if (pool.tag == tag) return pool.prefab;
        }
        return null;
    }
}

