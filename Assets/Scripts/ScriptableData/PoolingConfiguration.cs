using UnityEngine;

[CreateAssetMenu(fileName = "PoolingConfiguration", menuName = "Pooling/Configuration")]
public class PoolingConfiguration : ScriptableObject
{
    [System.Serializable]
    public class PoolInfo
    {
        public GameObject prefab;
        public int initialSize;
    }

    public PoolInfo[] pools;
}