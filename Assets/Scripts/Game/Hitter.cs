using Managers;
using Managers.Game;
using UnityEngine;
using Utility;

namespace Game
{
    public class Hitter : MonoBehaviour
    {
        private int hitterId;
        private int price;
        private readonly HitterData hitterData = new HitterData();

        public int Price { get => price; }

        public void Initialize(GameConfiguration gameConfig, int hitterId)
        {
            this.hitterId = hitterId;
            this.price = gameConfig.InitialHitterPrice * hitterId;
            hitterData.Initialize(0, gameConfig.InitialCoinEarning, gameConfig.InitialUpgradeCost);
        }

        public virtual bool ActivateHitter()
        {
            if (ServiceLocator.Resolve<GameManager>().SpendGold(price))
            {
                gameObject.SetActive(true);
                return true;
            }
            return false;
        }

        public bool Upgrade()
        {
           if(ServiceLocator.Resolve<GameManager>().SpendGold(hitterData.GoldPerTap))
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