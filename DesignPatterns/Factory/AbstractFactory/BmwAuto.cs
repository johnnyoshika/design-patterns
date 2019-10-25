using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Factory.AbstractFactory
{
    public abstract class BmwAuto : IAuto
    {
        public abstract string? Name { get; set; }

        public string TurnOn => $"{Name} On";
        public string TurnOff => $"{Name} Off";

    }

    public class BmwM3Auto : BmwAuto
    {
        public override string? Name { get; set; } = "BMW M3";
    }


    public class Bmw740iAuto : BmwAuto
    {
        public override string? Name { get; set; } = "BMW 740i";
    }

    public class Bmw328iAuto : BmwAuto
    {
        public override string? Name { get; set; } = "BMW 328i";
    }
}
