using Managers.Game;
using UnityEngine;
using Utility;

namespace Managers
{
    public class MainManager : ManagerBase
    {
        [SerializeField] private ManagerBase[] managers;

        private void Awake()
        {
            ServiceLocator.Register<MainManager>(this);
        }
        public override void Initialize(GameConfiguration gameConfig)
        {
            foreach (var manager in managers)
            {
                manager.Initialize(gameConfig);
            }
        }
    }
}

