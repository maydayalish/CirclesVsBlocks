using TMPro;
using UnityEngine;
using Utility;

namespace Managers.UI
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI goldText;
        public void Initialize()
        {
            ServiceLocator.Resolve<EventManager>().RegisterEvent<int>("OnCurrencyAmountChanged_Gold", OnGoldAmountChanged);
        }

        private void OnGoldAmountChanged(int newAmount)
        {
            goldText.text = newAmount + "";
        }
    }
}