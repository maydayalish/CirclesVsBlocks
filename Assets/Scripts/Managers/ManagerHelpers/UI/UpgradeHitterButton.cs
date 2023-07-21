using Managers.Game;
using System.Drawing;
using TMPro;
using UnityEngine;
using Utility;

namespace Managers.UI
{
    public class UpgradeHitterButton : BuyButton
    {
        [SerializeField] private readonly int hitterId;
        [SerializeField] private readonly TextMeshProUGUI levelText;

        public override void Initialize(GameConfiguration gameConfig)
        {
            UpdateLevelText(1);
            priceText.text = gameConfig.InitialUpgradeCost + "";
        }
        public override void HandleButtonClicked()
        {
           
        }

        public void OnHitterUpgraded()
        {

        }

        private void UpdateLevelText(int level)
        {
            levelText.text = "< size = '38'>Lv</size > " + 1;
        }
    }
}