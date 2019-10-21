using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Decorator
{
    public abstract class PizzaDecorator : Pizza
    {
        public PizzaDecorator(string description, Pizza pizza) : base(description) => Pizza = pizza;

        protected Pizza Pizza { get; }

        public override decimal CalculateCost() => Pizza.CalculateCost();
        public override string GetDescription() => $"{Pizza.GetDescription()}, {Description}";
    }

    public class Cheese : PizzaDecorator
    {
        public Cheese(Pizza pizza) : base("Cheese", pizza)
        {
        }

        public override decimal CalculateCost() => Pizza.CalculateCost() + 1.25m;
    }

    public class Peppers : PizzaDecorator
    {
        public Peppers(Pizza pizza) : base("Peppers", pizza)
        {
        }

        public override decimal CalculateCost() => Pizza.CalculateCost() + 2m;
    }

    public class Ham : PizzaDecorator
    {
        public Ham(Pizza pizza) : base("Ham", pizza)
        {
        }

        public override decimal CalculateCost() => Pizza.CalculateCost() + 1m;
    }
}
