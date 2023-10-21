using System;
using System.Collections.Generic;

namespace DeveloperSample.Container
{
    public class Container
    {
        Dictionary<Type, Type> hi = new Dictionary<Type, Type>();
        public void Bind(Type interfaceType, Type implementationType) {
            hi.Add(interfaceType, implementationType);
        }
        public T Get<T>() {
            return (T)Activator.CreateInstance(hi[typeof(T)]);
        }
    }
}