using Managers.Pool;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class PoolingManager : ManagerBase
    {
        [SerializeField] private PoolingConfiguration configuration;
        private Dictionary<string, Queue<GameObject>> objectPools = new Dictionary<string, Queue<GameObject>>();

        public override void Initialize()
        {
            base.Initialize();
            if (configuration == null)
            {
                Debug.LogError("No PoolingConfiguration assigned!");
                return;
            }

            foreach (var poolInfo in configuration.Pools)
            {
                CreateObjectPool(poolInfo.Prefab, poolInfo.InitialSize, poolInfo.GoBackOnDisable);
            }
        }

        private void CreateObjectPool(PoolElement prefab, int initialSize, bool goBackOnDisable)
        {
            string prefabName = prefab.name;
            if (!objectPools.ContainsKey(prefabName))
            {
                objectPools[prefabName] = new Queue<GameObject>();

                for (int i = 0; i < initialSize; i++)
                {
                    PoolElement newPoolElement = Instantiate(prefab.gameObject).GetComponent<PoolElement>();
                    GameObject poolObj = newPoolElement.gameObject;
                    poolObj.SetActive(false);
                    objectPools[prefabName].Enqueue(poolObj);
                    newPoolElement.Initialize(prefabName);
                }
            }
            else
            {
                Debug.LogError("Pool creation error. The pool called " + prefabName + " has already been created. Prefab name of a pool element is a key and must be unique");
            }
        }

        public GameObject GetPooledObject(string poolId)
        {
            if (objectPools.ContainsKey(poolId))
            {
                if (objectPools[poolId].Count > 0)
                {
                    GameObject obj = objectPools[poolId].Dequeue();
                    obj.SetActive(true);
                    return obj;
                }
                else
                {
                    Debug.LogWarning("Object pool for prefab " + poolId + " is empty. Consider increasing the initial size.");
                }
            }
            else
            {
                Debug.LogError("Object pool for prefab " + poolId + " does not exist. Make sure it's added to the configuration.");
            }
            return null;
        }

        public void ReturnToPool(PoolElement poolElement)
        {
            string poolId = poolElement.PoolId;
            if (objectPools.ContainsKey(poolId))
            {
                objectPools[poolId].Enqueue(poolElement.gameObject);
            }
            else
            {
                Debug.LogError("Object pool for prefab " + poolId + " does not exist. Make sure it's added to the configuration.");
            }
        }
    }
}
