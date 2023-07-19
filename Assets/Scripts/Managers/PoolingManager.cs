using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    [SerializeField] private PoolingConfiguration configuration;

    private Dictionary<GameObject, Queue<GameObject>> objectPools = new Dictionary<GameObject, Queue<GameObject>>();

    private void Awake()
    {
        InitializePools();
    }

    private void InitializePools()
    {
        if (configuration == null)
        {
            Debug.LogError("No PoolingConfiguration assigned to PoolingManager!");
            return;
        }

        foreach (var poolInfo in configuration.pools)
        {
            CreateObjectPool(poolInfo.prefab, poolInfo.initialSize);
        }
    }

    private void CreateObjectPool(GameObject prefab, int initialSize)
    {
        if (!objectPools.ContainsKey(prefab))
        {
            objectPools[prefab] = new Queue<GameObject>();

            for (int i = 0; i < initialSize; i++)
            {
                GameObject newObj = Instantiate(prefab);
                newObj.SetActive(false);
                objectPools[prefab].Enqueue(newObj);
            }
        }
    }

    public GameObject GetPooledObject(GameObject prefab)
    {
        if (objectPools.ContainsKey(prefab))
        {
            if (objectPools[prefab].Count > 0)
            {
                GameObject obj = objectPools[prefab].Dequeue();
                obj.SetActive(true);
                return obj;
            }
            else
            {
                Debug.LogWarning("Object pool for prefab " + prefab.name + " is empty. Consider increasing the initial size.");
            }
        }
        else
        {
            Debug.LogError("Object pool for prefab " + prefab.name +" does not exist. Make sure it's added to the configuration.");
        }

        return null;
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        objectPools[obj.GetComponent<GameObject>()].Enqueue(obj);
    }
}