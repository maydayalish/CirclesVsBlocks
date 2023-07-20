using Managers;
using Managers.Event;
using Utility;

namespace Game
{
    public class Currency
    {
        private EventManager eventManager;
        private IntValue currentValue = new IntValue();

        public IntValue CurrentValue { get => currentValue; }

        public void Initialize(int currencyId, int initialAmount)
        {
            eventManager = ServiceLocator.Resolve<EventManager>();
            SetCurrency(initialAmount);
        }

        public void EarnCurrency(IntValue addedValue)
        {
            SetCurrency(currentValue.value + addedValue.value);
        }

        public bool SpendCurrency(IntValue spentValue)
        {
            if (spentValue.value > currentValue.value)
            {
                return false;
            }
            SetCurrency(currentValue.value - spentValue.value);
            return true;
        }

        private void SetCurrency(int newAmount)
        {
            currentValue.value = newAmount;
            eventManager.TriggerEvent("OnCurrencyAmountChanged", currentValue);
        }
    }
}