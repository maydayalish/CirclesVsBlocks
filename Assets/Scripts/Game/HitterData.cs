using System.Diagnostics;
using UnityEngine;

namespace Game
{
    public class HitterData
    {
        private int currentLevel;
        private int goldPerTap;
        private int upgradeCost;

        public int GoldPerTap { get => goldPerTap; }
        public int UpgradeCost { get => upgradeCost; }
        public int CurrentLevel { get => currentLevel; }

        public void Initialize(int currentLevel, int goldPerTap, int upgradeCost)
        {
            this.currentLevel = currentLevel;
            this.goldPerTap = goldPerTap;
            this.upgradeCost = upgradeCost;
        }

        public void Upgrade()
        {
            currentLevel++;
            goldPerTap = UpgradeHandler.CalculateEarning(currentLevel);
            upgradeCost = UpgradeHandler.CalculateCost(currentLevel);
            UnityEngine.Debug.Log("Upgrade Cost Updated: " + upgradeCost);
        }
    }
}