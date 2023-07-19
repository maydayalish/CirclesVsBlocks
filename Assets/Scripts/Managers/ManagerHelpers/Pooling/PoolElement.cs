using UnityEngine;
using Utility;

namespace Managers.Pool
{
    public class PoolElement : MonoBehaviour
    {
        private string poolId;
        private bool goBackOnDisable;
        private bool isApplicationQuitting;

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

