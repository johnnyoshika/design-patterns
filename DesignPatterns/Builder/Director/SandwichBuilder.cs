using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder.Director
{
    public abstract class SandwichBuilder
    {
        protected Sandwich Sandwich { get; set; } = new Sandwich();

        public abstract SandwichBuilder Toast();
        public abstract SandwichBuilder AddCondiments();
        public abstract SandwichBuilder ApplyMeat();
        public abstract SandwichBuilder ApplyCheese();

        public Sandwich GetSandwich() => Sandwich;

        public void Clear() => Sandwich = new Sandwich();
    }

    public class HamSandwichBuilder : SandwichBuilder
    {
        public override SandwichBuilder AddCondiments()
        {
            Sandwich.Mayo = false;
            Sandwich.Mustard = true;
            return this;
        }

        public override SandwichBuilder ApplyCheese()
        {
            Sandwich.Cheese = CheeseType.Swiss;
            return this;
        }

        public override SandwichBuilder ApplyMeat()
        {
            Sandwich.Meat = MeatType.Ham;
            return this;
        }

        public override SandwichBuilder Toast()
        {
            Sandwich.Toasted = true;
            return this;
        }
    }

    public class TurkeySandwichBuilder : SandwichBuilder
    {
        public override SandwichBuilder AddCondiments()
        {
            Sandwich.Mayo = true;
            Sandwich.Mustard = false;
            return this;
        }

        public override SandwichBuilder ApplyCheese()
        {
            Sandwich.Cheese = CheeseType.Cheddar;
            return this;
        }

        public override SandwichBuilder ApplyMeat()
        {
            Sandwich.Meat = MeatType.Turkey;
            return this;
        }

        public override SandwichBuilder Toast()
        {
            Sandwich.Toasted = true;
            return this;
        }
    }
}
