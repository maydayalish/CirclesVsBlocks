using Managers;
using Utility;
using System.Numerics;

namespace Game
{
    [System.Serializable]
    public class Currency
    {
        public string currencyId;
        private BigInteger currentValue;

        public BigInteger CurrentValue { get => currentValue; }

        public void Initialize(int initialAmount)
        {
            SetCurrency(initialAmount);
        }

        public void EarnCurrency(BigInteger addedValue)
        {
            SetCurrency(currentValue + addedValue);
        }

        public bool SpendCurrency(BigInteger spentValue)
        {
            if (spentValue > currentValue)
            {
                return false;
            }
            SetCurrency(currentValue - spentValue);
            return true;
        }

        private void SetCurrency(BigInteger newAmount)
        {
            currentValue = newAmount;
            ServiceLocator.Resolve<EventManager>().TriggerEvent("OnCurrencyAmountChanged_" + currencyId, currentValue);
        }
    }
}