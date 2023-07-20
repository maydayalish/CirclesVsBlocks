using Game;
using Managers.Game;
using Utility;

namespace Managers
{
    public class GameManager : ManagerBase
    {
        private GameConfiguration gameConfiguration;
        private Currency coin;
        private HitData fingerHitData;
        private HitData[] circlesHitData;

        public override void Initialize()
        {
            ServiceLocator.Register(this);
        }
    }
}

