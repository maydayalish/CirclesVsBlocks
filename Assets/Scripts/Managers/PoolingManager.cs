using Managers.Game;
using Managers.Pool;
using System.Collections.Generic;
using UnityEngine;
using Utility;

namespace Managers
{
    public class PoolingManager : ManagerBase
    {
        [SerializeField] private PoolingConfiguration configuration;
        private Dictionary<string, Queue<GameObject>> objectPools = new Dictionary<string, Queue<GameObject>>();

        public override void Initialize(GameConfiguration gameConfig)
        {
            ServiceLocator.Register(this);
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

        public GameObject GetPooledObject(string poolId, Vector3 position)
        {
            if (objectPools.ContainsKey(poolId))
            {
                if (objectPools[poolId].Count > 0)
                {
                    GameObject obj = objectPools[poolId].Dequeue();
                    obj.transform.position = position;
                    obj.SetActive(true);
                    return obj;
                }
                else
                {
                    if (CreatePoolObjectFromId(poolId))
                    {
                        GetPooledObject(poolId, position);
                    }
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

        private void CreateObjectPool(PoolElement prefab, int initialSize, bool goBackOnDisable)
        {
            string prefabName = prefab.name;
            if (!objectPools.ContainsKey(prefabName))
            {
                objectPools[prefabName] = new Queue<GameObject>();

                for (int i = 0; i < initialSize; i++)
                {
                    CreatePoolObject(prefab, goBackOnDisable);
                }
            }
            else
            {
                Debug.LogError("Pool creation error. The pool called " + prefabName + " has already been created. Prefab name of a pool element is a key and must be unique");
            }
        }

        private GameObject CreatePoolObjectFromId(string poolId)
        {
            var poolInfo = configuration.GetPoolInfoById(poolId);
            if (poolInfo != null)
            {
                return CreatePoolObject(poolInfo.Prefab, poolInfo.GoBackOnDisable);
            }
            return null;
        }

        private GameObject CreatePoolObject(PoolElement poolElement, bool goBackOnDisable)
        {
            GameObject newPoolObject = Instantiate(poolElement.gameObject);
            newPoolObject.SetActive(false);
            newPoolObject.GetComponent<PoolElement>().Initialize(goBackOnDisable, poolElement.name);
            objectPools[poolElement.name].Enqueue(newPoolObject);
            return newPoolObject;
        }
    }
}
