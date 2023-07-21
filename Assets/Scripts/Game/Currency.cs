using Managers;
using Utility;

namespace Game
{
    [System.Serializable]
    public class Currency
    {
        public string currencyId;
        private int currentValue;

        public int CurrentValue { get => currentValue; }

        public void Initialize(int initialAmount)
        {
            SetCurrency(initialAmount);
        }

        public void EarnCurrency(int addedValue)
        {
            SetCurrency(currentValue + addedValue);
        }

        public bool SpendCurrency(int spentValue)
        {
            if (spentValue > currentValue)
            {
                return false;
            }
            SetCurrency(currentValue - spentValue);
            return true;
        }

        private void SetCurrency(int newAmount)
        {
            currentValue = newAmount;
            ServiceLocator.Resolve<EventManager>().TriggerEvent("OnCurrencyAmountChanged_" + currencyId, currentValue);
        }
    }
}