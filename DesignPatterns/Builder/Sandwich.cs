using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder
{
    public class Sandwich
    {
        public bool Toasted { get; set; }
        public bool Mustard { get; set; }
        public bool Mayo { get; set; }
        public MeatType Meat { get; set; }
        public CheeseType Cheese { get; set; }

        public override string ToString() =>
            $"Toasted: {Toasted} | Mustard: {Mustard} | Mayo: {Mayo} | Meat: {Meat} | Cheese: {Cheese}";
    }

    public enum MeatType
    {
        None,
        Turkey,
        Ham,
        Beef
    }

    public enum CheeseType
    {
        None,
        Swiss,
        Cheddar,
        Mozzarella
    }
}
