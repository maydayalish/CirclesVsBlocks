using Game;
using Managers.Game;
using TMPro;
using UnityEngine;
using Utility;

namespace Managers.UI
{
    public class UpgradeHitterButton : BuyButton
    {
        [SerializeField] protected int hitterId;
        [SerializeField] protected TextMeshProUGUI levelText;

        public override void Initialize(GameConfiguration gameConfig)
        {
            UpdateLevelText(1);
            priceText.text = gameConfig.InitialUpgradeCost + "";
            
        }
        public override void HandleButtonClicked()
        {
            ServiceLocator.Resolve<GameManager>().UpgradeHitter(hitterId);
        }

        public void OnHitterUpgraded(HitterData hitterData)
        {
            UpdateLevelText(hitterData.CurrentLevel + 1);
            priceText.text = NumberFormatter.FormatNumber(hitterData.UpgradeCost);
        }

        private void UpdateLevelText(int level)
        {
            levelText.text = "Lv: " + level;
        }
    }
}