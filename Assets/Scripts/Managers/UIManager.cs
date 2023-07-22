using Managers.Game;
using Managers.UI;
using UnityEngine;
using Utility;

namespace Managers
{
    public class UIManager : ManagerBase
    {
        [SerializeField] private GameUI gamePanel;
        [SerializeField] private UpgradeUI upgradePanel;
        [SerializeField] private GameObject loadingPanel;

        public override void Initialize(GameConfiguration gameConfig)
        {
            gamePanel.Initialize();
            upgradePanel.Initialize(gameConfig);
            loadingPanel.SetActive(false);
        }
    }
}