using Game;
using Managers.Game;
using System.Numerics;
using UnityEngine;
using Utility;

namespace Managers.UI
{
    public class UpgradeUI : MonoBehaviour
    {
        [SerializeField] private UpgradeHitterButton[] upgradeHitterButtons;
        [SerializeField] private BuyCircleButton buyCircleButton;
        public void Initialize(GameConfiguration gameConfig)
        {
            var eventManager = ServiceLocator.Resolve<EventManager>();

            eventManager.RegisterEvent<BigInteger>("OnCurrencyAmountChanged_Gold", OnGoldAmountChanged);
            eventManager.RegisterEvent<int>("OnHitterAcquired", OnHitterAcquired);
            eventManager.RegisterEvent<int>("OnHitterUpgraded", OnHitterUpgraded);

            for (int i = 0; i < upgradeHitterButtons.Length; i++)
            {
                upgradeHitterButtons[i].Initialize(gameConfig);
            }
            buyCircleButton.Initialize(gameConfig);
        }

        public void OnGoldAmountChanged(BigInteger newAmount)
        {
            //Added to polish if an item is too expensive to buy
        }

        private void OnHitterAcquired(int hitterId)
        {
            upgradeHitterButtons[hitterId].gameObject.SetActive(true);
        }

        private void OnHitterUpgraded(int hitterId)
        {
            Hitter hitter = ServiceLocator.Resolve<GameManager>().GetHitter(hitterId);
            if(hitter != null)
            {
                if(hitterId < upgradeHitterButtons.Length)
                {
                    upgradeHitterButtons[hitterId].OnHitterUpgraded(hitter.HitterData);
                }
            }
        }
    }
}