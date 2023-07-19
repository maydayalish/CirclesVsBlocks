using UnityEngine;

namespace Managers.Pool
{
    [CreateAssetMenu(fileName = "PoolingConfiguration", menuName = "Pooling/Configuration")]
    public class PoolingConfiguration : ScriptableObject
    {
        [SerializeField] private PoolInfo[] pools;

        public PoolInfo[] Pools { get => pools; }

        public PoolInfo GetPoolInfoById(string poolId)
        {
            for (int i = 0; i < pools.Length; i++)
            {
                if (pools[i].Prefab.name.Equals(poolId))
                {
                    return pools[i];
                }
            }
            return null;
        }

        [System.Serializable]
        public class PoolInfo
        {
            [SerializeField] private PoolElement prefab;
            [SerializeField] private int initialSize;
            [SerializeField] private bool goBackOnDisable;

            public PoolElement Prefab { get => prefab; }
            public int InitialSize { get => initialSize; }
            public bool GoBackOnDisable { get => goBackOnDisable; }
        }
    }
}
