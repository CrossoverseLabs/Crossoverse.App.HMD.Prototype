using System;
using System.Collections.Generic;

namespace Crossoverse.HMDApp.Quest.Lifecycle
{
    public class ServiceLocator
    {
        public static ServiceLocator Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new();
                }
                return _instance;
            }
        }

        private static ServiceLocator _instance;

        private readonly Dictionary<Type, object> _services = new();

        private ServiceLocator()
        {
        }

        public bool TryRegister<T>(T instance) where T : class
        {
            return _services.TryAdd(typeof(T), instance);
        }

        public void Unregister<T>(T instance) where T : class
        {
            var type = typeof(T);

            foreach (var i in type.GetInterfaces())
            {
                if (_services.ContainsKey(i) && Equals(_services[i], instance))
                {
                    _services.Remove(i);
                }
            }

            _services.Remove(type);
        }

        public bool TryGetService<T>(out T service) where T : class
        {
            var type = typeof(T);

            service = _services.ContainsKey(type) ? _services[type] as T : null;

            return service != null;
        }

        public bool IsRegistered<T>() where T : class
        {
            return _services.ContainsKey(typeof(T));
        }
    }
}
