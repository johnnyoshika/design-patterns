using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Decorator
{
    // This is our "unchangeable" component
    public abstract class Pizza
    {
        public Pizza(string description) => Description = description;

        public string Description { get; }

        public virtual string GetDescription() => Description;
        public abstract decimal CalculateCost();
    }

    // These are our concrete components
    public class SmallPizza : Pizza
    {
        public SmallPizza() : base("Small Pizza")
        {
        }

        public override decimal CalculateCost() => 3 ;
    }

    public class MediumPizza : Pizza
    {
        public MediumPizza() : base("Medium Pizza")
        {
        }

        public override decimal CalculateCost() => 6;
    }

    public class LargePizza : Pizza
    {
        public LargePizza() : base("Large Pizza")
        {
        }

        public override decimal CalculateCost() => 9 ;
    }
}
