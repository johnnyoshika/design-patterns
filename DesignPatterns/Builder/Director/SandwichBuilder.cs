using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder.Director
{
    public abstract class SandwichBuilder
    {
        protected Sandwich Sandwich { get; set; } = new Sandwich();

        public abstract void Toast();
        public abstract void AddCondiments();
        public abstract void ApplyMeat();
        public abstract void ApplyCheese();

        public Sandwich GetSandwich() => Sandwich;

        public void Clear() => Sandwich = new Sandwich();
    }

    public class HamSandwichBuilder : SandwichBuilder
    {
        public override void AddCondiments()
        {
            Sandwich.Mayo = false;
            Sandwich.Mustard = true;
        }

        public override void ApplyCheese()
        {
            Sandwich.Cheese = CheeseType.Swiss;
        }

        public override void ApplyMeat()
        {
            Sandwich.Meat = MeatType.Ham;
        }

        public override void Toast()
        {
            Sandwich.Toasted = true;
        }
    }

    public class TurkeySandwichBuilder : SandwichBuilder
    {
        public override void AddCondiments()
        {
            Sandwich.Mayo = true;
            Sandwich.Mustard = false;
        }

        public override void ApplyCheese()
        {
            Sandwich.Cheese = CheeseType.Cheddar;
        }

        public override void ApplyMeat()
        {
            Sandwich.Meat = MeatType.Turkey;
        }

        public override void Toast()
        {
            Sandwich.Toasted = true;
        }
    }
}
