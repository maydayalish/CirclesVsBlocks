using Game;
using Managers.Game;
using UnityEngine;
using Utility;

namespace Managers
{
    public class GameManager : ManagerBase
    {
        [SerializeField] private GameConfiguration gameConfiguration;
        [SerializeField] private readonly Currency gold;
        [SerializeField] private readonly Hitter[] hitters;

        public Currency Gold { get => gold; }

        public override void Initialize()
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
            ServiceLocator.Resolve<EventManager>().TriggerEvent("OnGoldEarned", amount);
        }

        public bool SpendGold(int amount)
        {
            if(gold.SpendCurrency(amount))
            {
                ServiceLocator.Resolve<EventManager>().TriggerEvent("OnGoldSpent", amount);
                return true;
            }
            return false;
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

