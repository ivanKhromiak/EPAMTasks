using System;
using System.Collections.Generic;
using System.Linq;

namespace InversionOfControl
{
    public class Container
    {
        private readonly Dictionary<Type, Func<object>> _registerTypes = new Dictionary<Type, Func<object>>();

        public void RegisterTransient<TService, TImplementation>() where TImplementation : TService
        {
            _registerTypes.Add(typeof(TImplementation), () => CreateInstance(typeof(TImplementation)));
        }

        public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
        {
            var obj = CreateInstance(typeof(TImplementation));
            _registerTypes.Add(typeof(TImplementation), () => obj);
        }

        public TImplementation Resolve<TImplementation>()
        {
            return (TImplementation)CreateInstance(typeof(TImplementation));
        }

        private object CreateInstance(Type type)
        {
            Func<object> registerType;
            if (_registerTypes.TryGetValue(type, out registerType))
            {
                return _registerTypes[type];
            }

            var constructor = type.GetConstructors()
                .OrderByDescending(c => c.GetParameters().Length)
                .First();

            var args = constructor.GetParameters()
                .Select(param => CreateInstance(param.ParameterType))
                .ToArray(); 

            return constructor.Invoke(args);
        }
    }
}
