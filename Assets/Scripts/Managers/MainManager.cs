using System;
using UnityEngine;

namespace Managers
{
    public class MainManager : MonoBehaviour
    {
        [SerializeField] private ManagerBase[] managers;

        private void Awake()
        {
            foreach(var manager in managers)
            {
                manager.Initialize();
            }
        }
    }
}

