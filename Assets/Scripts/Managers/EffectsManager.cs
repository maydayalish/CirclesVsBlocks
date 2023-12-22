using UnityEngine;
using DG.Tweening;
using Utility;
using Managers.Game;

namespace Managers
{
    public class EffectsManager : ManagerBase
    {
        [SerializeField] private float punchDuration;
        [SerializeField] private Vector3 punchSize;
        [SerializeField] private string[] particlePoolIds;

        private PoolingManager pooling; //Effects shall be called often

        public override void Initialize(GameConfiguration config)
        {
            ServiceLocator.Register(this);
            pooling = ServiceLocator.Resolve<PoolingManager>();
        }
        public void Play(GameObject punchedObject, Vector3 particlePoint)
        {
            int randomParticleIdIndex = Random.Range(0, particlePoolIds.Length);
            punchedObject.transform.DORewind();
            punchedObject.transform.DOPunchScale(punchSize, punchDuration);
            pooling.GetPooledObject(particlePoolIds[randomParticleIdIndex], particlePoint);
        }
    }
}