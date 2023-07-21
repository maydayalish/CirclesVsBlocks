using Unity.Services.RemoteConfig;
using UnityEngine;

namespace Managers.Game
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Game/Configuration")]
    public class GameConfiguration : ScriptableObject
    {
        [SerializeField] private int initialCoin;
        [SerializeField] private int initialCoinEarning;
        [SerializeField] private int initialUpgradeCost;
        [SerializeField] private int initialHitterPrice;
        [SerializeField] private float coinEarningScalingFactor;
        [SerializeField] private float upgradeCostScalingBase;
        [SerializeField] private float hitterPriceMultiplier;

        public int InitialCoin { get => initialCoin; }
        public int InitialCoinEarning { get => initialCoinEarning; }
        public int InitialUpgradeCost { get => initialUpgradeCost; }
        public int InitialHitterPrice { get => initialHitterPrice; }
        public float CoinEarningScalingFactor { get => coinEarningScalingFactor; }
        public float UpgradeCostScalingBase { get => upgradeCostScalingBase; }
        public float HitterPriceMultiplier { get => hitterPriceMultiplier; }

        public void ApplyConfiguration()
        {
            initialCoin = RemoteConfigService.Instance.appConfig.GetInt("InitialCoin", initialCoin);
            initialCoinEarning = RemoteConfigService.Instance.appConfig.GetInt("InitialCoinEarning", initialCoinEarning);
            initialUpgradeCost = RemoteConfigService.Instance.appConfig.GetInt("InitialUpgradeCost", initialUpgradeCost);
            initialHitterPrice = RemoteConfigService.Instance.appConfig.GetInt("InitialHitterPrice", initialHitterPrice);
            coinEarningScalingFactor = RemoteConfigService.Instance.appConfig.GetFloat("CoinEarningScalingFactor", coinEarningScalingFactor);
            upgradeCostScalingBase = RemoteConfigService.Instance.appConfig.GetFloat("UpgradeCostScalingBase", upgradeCostScalingBase);
            hitterPriceMultiplier = RemoteConfigService.Instance.appConfig.GetFloat("HitterPriceMultiplier", hitterPriceMultiplier);
        }
    }
}