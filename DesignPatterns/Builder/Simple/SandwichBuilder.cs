using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder.Simple
{
    public abstract class SandwichBuilder
    {
        public Sandwich Build() =>
            ApplyCheese(
                ApplyMeat(
                    AddCondiments(
                        Toast(new Sandwich()))));

        public abstract Sandwich Toast(Sandwich sandwich);
        public abstract Sandwich AddCondiments(Sandwich sandwich);
        public abstract Sandwich ApplyMeat(Sandwich sandwich);
        public abstract Sandwich ApplyCheese(Sandwich sandwich);
    }

    public class HamSandwichBuilder : SandwichBuilder
    {
        public override Sandwich AddCondiments(Sandwich sandwich)
        {
            sandwich.Mayo = false;
            sandwich.Mustard = true;
            return sandwich;
        }

        public override Sandwich ApplyCheese(Sandwich sandwich)
        {
            sandwich.Cheese = CheeseType.Swiss;
            return sandwich;
        }

        public override Sandwich ApplyMeat(Sandwich sandwich)
        {
            sandwich.Meat = MeatType.Ham;
            return sandwich;
        }

        public override Sandwich Toast(Sandwich sandwich)
        {
            sandwich.Toasted = true;
            return sandwich;
        }
    }

    public class TurkeySandwichBuilder : SandwichBuilder
    {
        public override Sandwich AddCondiments(Sandwich sandwich)
        {
            sandwich.Mayo = true;
            sandwich.Mustard = false;
            return sandwich;
        }

        public override Sandwich ApplyCheese(Sandwich sandwich)
        {
            sandwich.Cheese = CheeseType.Cheddar;
            return sandwich;
        }

        public override Sandwich ApplyMeat(Sandwich sandwich)
        {
            sandwich.Meat = MeatType.Turkey;
            return sandwich;
        }

        public override Sandwich Toast(Sandwich sandwich)
        {
            sandwich.Toasted = true;
            return sandwich;
        }
    }
}
