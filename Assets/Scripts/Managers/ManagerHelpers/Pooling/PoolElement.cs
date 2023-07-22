using UnityEngine;
using Utility;

namespace Managers.Pool
{
    public class PoolElement : MonoBehaviour
    {
        private bool goBackOnDisable;
        private bool isApplicationQuitting;
        private string poolId;

        public string PoolId { get => poolId; }

        public void Initialize(bool gBackOnDisable, string pId)
        {
            poolId = pId;
            goBackOnDisable = gBackOnDisable;
        }
        public void ReturnToPool()
        {
            ServiceLocator.Resolve<PoolingManager>().ReturnToPool(this);
        }

        private void OnDisable()
        {
            if (!isApplicationQuitting && goBackOnDisable)
            {
                ReturnToPool();
            }
        }

        private void OnApplicationQuit()
        {
            isApplicationQuitting = true;
        }
    }
}

