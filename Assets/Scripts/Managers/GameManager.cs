using Game;
using Managers.Game;
using UnityEngine;
using Utility;

namespace Managers
{
    public class GameManager : ManagerBase
    {
        [SerializeField] private Currency gold;
        [SerializeField] private Hitter[] hitters;

        public Currency Gold { get => gold; }

        public override void Initialize(GameConfiguration gameConfiguration)
        {
            ServiceLocator.Register(this);
            UpgradeHandler.Initialize(gameConfiguration);
            gold.Initialize(gameConfiguration.InitialCoin);
            for (int i = 0; i < hitters.Length; i++)
            {
                hitters[i].Initialize(gameConfiguration, i);
            }
        }

        public void RunHitter(int hitterId)
        {
            hitters[hitterId].Hit();
        }

        public void EarnGold(int amount)
        {
            gold.EarnCurrency(amount);
        }

        public bool SpendGold(int amount)
        {
            return gold.SpendCurrency(amount);
        }

        public void UpgradeHitter(int hitterId)
        {
            hitters[hitterId].Upgrade();
        }

        public void BuyHitter()
        {
            for (int i = 0; i < hitters.Length; i++)
            {
                Hitter hitter = hitters[i];
                if (!hitter.gameObject.activeInHierarchy)
                {
                    if (hitter.ActivateHitter())
                    {
                        ServiceLocator.Resolve<EventManager>().TriggerEvent<int>("OnHitterAcquired", i);
                        return;
                    }
                }
            }
        }

        public Hitter GetHitter(int hitterId)
        {
            if(hitterId < hitters.Length)
            {
                return hitters[hitterId];
            }
            return null;
        }
    }
}

