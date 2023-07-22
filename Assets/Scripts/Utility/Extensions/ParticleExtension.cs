using UnityEngine;

namespace Utility.Extensions
{
    public static class ParticleExtension
    {
        //This was made to prevent code repetition of these two lines 
        public static void SimulateAndPlay(this ParticleSystem particleSystem)
        {
            particleSystem.Simulate(0, true, true);
            particleSystem.Play();
        }
    }
}