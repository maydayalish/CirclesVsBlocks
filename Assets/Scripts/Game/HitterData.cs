using System.Numerics;

namespace Game
{
    public class HitterData
    {
        private int currentLevel;
        private BigInteger goldPerTap;
        private BigInteger upgradeCost;

        public int CurrentLevel { get => currentLevel; }
        public BigInteger GoldPerTap { get => goldPerTap; }
        public BigInteger UpgradeCost { get => upgradeCost; }
       
        public void Initialize(int currentLevel, BigInteger goldPerTap, BigInteger upgradeCost)
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
        }
    }
}