using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        Dictionary<Type, Type> typeBindings = new Dictionary<Type, Type>();

        public void Bind(Type interfaceType, Type implementationType)
        {
            typeBindings.Add(interfaceType, implementationType);
        }

        public T Get<T>()
        {
            return (T)Activator.CreateInstance(typeBindings[typeof(T)]);
        }
    }
}
