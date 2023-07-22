using Utility;
using UnityEngine;
using Managers;
using Managers.Game;

namespace Game
{
    public class Circle : Hitter
    {
        private readonly int hitAnimHash = Animator.StringToHash("Hit"); //Works faster
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
                Delayer.Delay(1f, () => RepeatHit());
                return true;
            }
            return false;
        }

        public void RepeatHit()
        {
            Hit();
            hitAnimator.Play(hitAnimHash, 0, 0);
            effects.Play(enemy, hitPosition.position);
            Delayer.Delay(1f, ()=> RepeatHit());
        }
    }
}