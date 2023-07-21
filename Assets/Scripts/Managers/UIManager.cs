using Managers.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class UIManager : ManagerBase
    {
        [SerializeField] private GameUI gamePanel;
        [SerializeField] private UpgradeUI upgradePanel;
        public override void Initialize()
        {
            gamePanel.Initialize();
            upgradePanel.Initialize();
        }
    }
}