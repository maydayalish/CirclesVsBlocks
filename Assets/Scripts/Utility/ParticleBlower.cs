using UnityEngine;
using Utility.Extensions;

namespace Utility
{
    [RequireComponent(typeof(ParticleSystem))]
    public class ParticleBlower : MonoBehaviour
    {
        [SerializeField] private float deactivationTime;
        private ParticleSystem particle;
        private void Awake()
        {
            particle = GetComponent<ParticleSystem>();
        }
        private void OnEnable()
        {
            particle.SimulateAndPlay();
            Delayer.Delay(deactivationTime, ()=> gameObject.SetActive(false));
        }
    }
}