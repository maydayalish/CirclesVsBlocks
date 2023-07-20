using UnityEngine;

namespace Managers.Game
{
    public class GameConfiguration : ScriptableObject
    {
        [SerializeField] private int initialCoin;
        [SerializeField] private int initialCoinEarning;
        [SerializeField] private float coinEarningScalingFactor;
        [SerializeField] private int initialUpgradeCost;
        [SerializeField] private float upgradeCostScalingBase;

        public int InitialCoin { get => initialCoin; }
        public int InitialCoinEarning { get => initialCoinEarning; }
        public float CoinEarningScalingFactor { get => coinEarningScalingFactor; }
        public int InitialUpgradeCost { get => initialUpgradeCost; }
        public float UpgradeCostScalingBase { get => upgradeCostScalingBase; }
    }
}