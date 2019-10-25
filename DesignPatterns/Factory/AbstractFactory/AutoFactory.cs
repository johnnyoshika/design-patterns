using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Factory.AbstractFactory
{
    public interface IAutoFactory
    {
        // Creating separate methods like this makes this less extensible. May be better to have one method and pass in a parameter.
        IAuto CreateEconomyCar();
        IAuto CreateSportsCar();
        IAuto CreateLuxuryCar();
    }

    public class BmwFactory : IAutoFactory
    {
        public IAuto CreateEconomyCar() => new Bmw328iAuto();
        public IAuto CreateLuxuryCar() => new Bmw740iAuto();
        public IAuto CreateSportsCar() => new BmwM3Auto();
    }

    public class MiniFactory : IAutoFactory
    {
        public IAuto CreateEconomyCar() => new MiniAuto { Name = "Base Mini" };
        public IAuto CreateLuxuryCar() => new MiniAuto { Name = "Mini with luxury package" };
        public IAuto CreateSportsCar() => new MiniAuto { Name = "Mini with sports package" };
    }

    public class NullFactory : IAutoFactory
    {
        public IAuto CreateEconomyCar() => new NullAuto();

        public IAuto CreateSportsCar() => new NullAuto();

        public IAuto CreateLuxuryCar() => new NullAuto();
    }
}
