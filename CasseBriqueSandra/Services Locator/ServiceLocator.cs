using System;
using System.Collections.Generic;

namespace CasseBriqueSandra
{
    public static class ServiceLocator
    {
        private static readonly Dictionary<Type, object> listServices = new Dictionary<Type, object>();
        public static void RegisterService<T>(T service)
        {
            listServices[typeof(T)] = service;
        }
        public static T GetService<T>()
        {
            return (T)listServices[typeof(T)];
        }
    }
}

