using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Factory.FactoryMethod
{
    public interface IAutoFactory
    {
        IAuto CreateAuto();
    }

    class BmwFactory : IAutoFactory
    {
        public IAuto CreateAuto() => new BmwAuto();
    }

    class MiniFactory : IAutoFactory
    {
        public IAuto CreateAuto() => new MiniAuto(); // this factory may set necessary properties in MiniAuto
    }

    class NullFactory : IAutoFactory
    {
        public IAuto CreateAuto() => new NullAuto();
    }
}
