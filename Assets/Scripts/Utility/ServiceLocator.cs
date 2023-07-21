using Managers;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class ServiceLocator
    {
        private static readonly Dictionary<Type, ManagerBase> services = new Dictionary<Type, ManagerBase>();

        public static void Register<T>(T service) where T : ManagerBase
        {
            services[typeof(T)] = service;
        }

        public static T Resolve<T>() where T : ManagerBase
        {
            ManagerBase service;
            if (services.TryGetValue(typeof(T), out service))
                return (T)service;

            Debug.LogError("Service " + typeof(T) + " not found.");
            return default(T);
        }
    }
}

