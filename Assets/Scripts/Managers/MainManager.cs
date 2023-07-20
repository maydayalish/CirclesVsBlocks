using UnityEngine;

namespace Managers
{
    public class MainManager : MonoBehaviour
    {
        [SerializeField] private readonly ManagerBase[] managers;

        private void Awake()
        {
            foreach(var manager in managers)
            {
                manager.Initialize();
            }
        }
    }
}

