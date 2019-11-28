using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.ServiceLocator
{
    public class ServiceLocator
    {
        static readonly Hashtable _services = new Hashtable();

        public static void AddService<T>(string name, T t) => _services.Add(name, t);
        public static T GetService<T>(string name) => (T)(_services[name] ?? throw new NotSupportedException());
    }
}
