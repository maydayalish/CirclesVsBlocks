using Utility;
using UnityEngine;

namespace Game
{
    public class Circle : Hitter
    {
        private readonly int hitAnimHash = Animator.StringToHash("Hit"); //Works faster
        [SerializeField] private Animator hitAnimator;
       
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
            Delayer.Delay(1f, ()=> RepeatHit());
        }
    }
}