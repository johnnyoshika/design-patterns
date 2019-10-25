using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Factory
{
    public interface IAuto
    {
        string? Name { get; set; }

        string TurnOn { get; }
        string TurnOff { get; }
    }

    public class BmwAuto : IAuto
    {
        public string? Name { get; set; }

        public string TurnOn => "BMW On";
        public string TurnOff => "BMW Off";

    }

    public class MiniAuto : IAuto
    {
        public string? Name { get; set; } = "Mini";
        public string TurnOn => $"{Name} On";
        public string TurnOff => $"{Name} Off";
    }

    public class NullAuto : IAuto
    {
        public string? Name { get; set; }
        public string TurnOn => "";
        public string TurnOff => "";

    }
}
