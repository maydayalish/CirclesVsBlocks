using Managers.Game;
using TMPro;
using UnityEngine;

namespace Managers.UI
{
    public abstract class BuyButton : MonoBehaviour
    {
        [SerializeField] protected TextMeshProUGUI priceText;

        public abstract void Initialize(GameConfiguration gameConfig);
        public abstract void HandleButtonClicked();
    }
}