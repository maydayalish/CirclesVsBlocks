using Managers.Game;
using Managers.UI;
using UnityEngine;

namespace Managers
{
    public class UIManager : ManagerBase
    {
        [SerializeField] private GameUI gamePanel;
        [SerializeField] private UpgradeUI upgradePanel;
        public override void Initialize(GameConfiguration gameConfig)
        {
            gamePanel.Initialize();
            upgradePanel.Initialize(gameConfig);
        }
    }
}