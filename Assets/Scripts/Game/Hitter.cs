using Managers;
using Managers.Game;
using System.Numerics;
using UnityEngine;
using Utility;

namespace Game
{
    public class Hitter : MonoBehaviour
    {
        private int hitterId;
        [SerializeField] private BigInteger price;
        private readonly HitterData hitterData = new HitterData();

        public BigInteger Price { get => price; }
        public int HitterId { get => hitterId; }

        public HitterData HitterData => hitterData;

        public virtual void Initialize(GameConfiguration gameConfig, int hitterId)
        {
            this.hitterId = hitterId;
            this.price = (BigInteger)(gameConfig.InitialHitterPrice * Mathf.Pow(10, hitterId - 1) * Mathf.Sign(hitterId));
            hitterData.Initialize(0, gameConfig.InitialCoinEarning, gameConfig.InitialUpgradeCost);
        }

        public virtual bool ActivateHitter()
        {
            if (ServiceLocator.Resolve<GameManager>().SpendGold(price))
            {
                gameObject.SetActive(true);
                ServiceLocator.Resolve<EventManager>().TriggerEvent<int>("OnHitterAcquired", hitterId);
                return true;
            }
            return false;
        }

        public bool Upgrade()
        {
           if(ServiceLocator.Resolve<GameManager>().SpendGold(hitterData.UpgradeCost))
           {
                hitterData.Upgrade();
                ServiceLocator.Resolve<EventManager>().TriggerEvent("OnHitterUpgraded", hitterId);
                return true;
           }
           return false;
        }

        public void Hit()
        {
            ServiceLocator.Resolve<GameManager>().EarnGold(hitterData.GoldPerTap);
        }
    }
}