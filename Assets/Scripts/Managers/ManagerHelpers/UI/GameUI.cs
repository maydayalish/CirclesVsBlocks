using System.Numerics;
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
            ServiceLocator.Resolve<EventManager>().RegisterEvent<BigInteger>("OnCurrencyAmountChanged_Gold", OnGoldAmountChanged);
        }

        private void OnGoldAmountChanged(BigInteger newAmount)
        {
            goldText.text = NumberFormatter.FormatNumber(newAmount);
        }
    }
}