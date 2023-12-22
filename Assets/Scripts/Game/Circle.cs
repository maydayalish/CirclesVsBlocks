using Utility;
using UnityEngine;
using Managers;
using Managers.Game;

namespace Game
{
    public class Circle : Hitter
    {
        private readonly int hitAnimHash = Animator.StringToHash("Hit"); //Works faster
        private int hitRepeater;
        private EffectsManager effects;
        private GameObject enemy;
        [SerializeField] private Transform hitPosition;
        [SerializeField] private Animator hitAnimator;

        public override void Initialize(GameConfiguration gameConfig, int hitterId)
        {
            base.Initialize(gameConfig, hitterId);
            effects = ServiceLocator.Resolve<EffectsManager>();
            enemy = ServiceLocator.Resolve<GameManager>().Enemy;
        }
        public override bool ActivateHitter()
        {
            if(base.ActivateHitter())
            {
                hitRepeater = Delayer.Delay(1f, () => RepeatHit());
                return true;
            }
            return false;
        }

        public void StopHitter()
        {
            Delayer.CancelDelay(hitRepeater);
        }

        public void RepeatHit()
        {
            Hit();
            hitAnimator.Play(hitAnimHash, 0, 0);
            effects.Play(enemy, hitPosition.position);
            hitRepeater = Delayer.Delay(1f, ()=> RepeatHit());
        }
    }
}