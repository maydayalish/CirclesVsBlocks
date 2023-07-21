using Managers.Game;
using UnityEngine;

namespace Game
{
    public class UpgradeHandler
    {
        private static int initialCoinEarning;
        private static float coinEarningScalingFactor;
        private static int initialUpgradeCost;
        private static float upgradeCostScalingBase;

        public static void Initialize(GameConfiguration gameConfig)
        {
            initialCoinEarning = gameConfig.InitialCoinEarning;
            coinEarningScalingFactor = gameConfig.CoinEarningScalingFactor;
            initialUpgradeCost = gameConfig.InitialUpgradeCost;
            upgradeCostScalingBase = gameConfig.UpgradeCostScalingBase;
        }

        public static int CalculateEarning(int level)
        {
            return initialCoinEarning * (int)Mathf.Pow(level, coinEarningScalingFactor);
        }

        public static int CalculateCost(int level)
        {
            return initialUpgradeCost * (int)Mathf.Pow(upgradeCostScalingBase, level);
        }
    }
}