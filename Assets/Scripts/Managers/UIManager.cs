using Managers.Game;
using Managers.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility;

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