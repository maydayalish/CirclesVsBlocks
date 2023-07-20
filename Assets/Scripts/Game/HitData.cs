using UnityEngine;

namespace Game
{
    public class HitData
    {
        private int goldPerTap;
        private int currentLevel;
        private int upgradeCost;

        public int GoldPerTap { get => goldPerTap; }
        public int CurrentLevel { get => currentLevel; }
        public int UpgradeCost { get => upgradeCost; }

        public void Update(int goldPerTap, int currentLevel, int upgradeCost)
        {
            this.goldPerTap = goldPerTap;
            this.currentLevel = currentLevel;
            this.upgradeCost = upgradeCost;
        }
    }
}