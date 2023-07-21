using UnityEngine;
using Utility;

namespace Managers.UI
{
    public class UpgradeUI : MonoBehaviour
    {
        public void Initialize()
        {
            ServiceLocator.Resolve<EventManager>().RegisterEvent<int>("OnCurrencyAmountChanged_Gold", OnGoldAmountChanged);
        }

        public void HandleUpgradeHitterButton()
        {

        }

        public void HandleAddCircleButton()
        {

        }

        public void OnGoldAmountChanged(int newAmount)
        {
            //Added to polish if an item is too expensive to buy
        }
    }
}