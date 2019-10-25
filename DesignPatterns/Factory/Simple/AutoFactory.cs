using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DesignPatterns.Factory.Simple
{
    public class AutoFactory
    {
        public AutoFactory()
        {
            LoadTypesICanReturn();
        }

        Dictionary<string, Type> Autos { get; } = new Dictionary<string, Type>();

        public IAuto CreateInstance(string carName)
        {
            var t = GetTypeToCreate(carName);
            if (t == null)
                return new NullAuto();
            else
                return Activator.CreateInstance(t) as IAuto ?? new NullAuto();
        }

        Type? GetTypeToCreate(string carName)
        {
            var auto = Autos.FirstOrDefault(a => a.Key.Contains(carName.ToLower()));
            if (auto.Equals(default))
                return null;
            else
                return auto.Value;
        }

        void LoadTypesICanReturn() =>
            Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterface(typeof(IAuto).ToString()) != null)
                .Where(t => t.Namespace == "DesignPatterns.Factory")
                .ToList()
                .ForEach(t => Autos.Add(t.Name.ToLower(), t));
    }
}
