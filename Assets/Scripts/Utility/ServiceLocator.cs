using System;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public class ServiceLocator
    {
        private static readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

        public static void Register<T>(T service)
        {
            services[typeof(T)] = service;
        }

        public static T Resolve<T>()
        {
            object service;
            if (services.TryGetValue(typeof(T), out service))
                return (T)service;

            Debug.LogError($"Service {typeof(T)} not found.");
            return default(T);
        }
    }
}

