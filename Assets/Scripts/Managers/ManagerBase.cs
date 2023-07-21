using Managers.Game;
using UnityEngine;

namespace Managers
{
    public abstract class ManagerBase : MonoBehaviour
    {
        public abstract void Initialize(GameConfiguration gameConfig);
    }
}

