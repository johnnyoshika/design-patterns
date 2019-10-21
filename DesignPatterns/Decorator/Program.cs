using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Decorator
{
    public static class Program
    {
        public static string Run()
        {
            Pizza largePizza = new LargePizza();

            // wrap large pizza with our cheese decorator
            largePizza = new Cheese(largePizza);

            // wrap our large cheese pizza with our ham decorator
            largePizza = new Ham(largePizza);

            return $"{largePizza.GetDescription()} cost: {largePizza.CalculateCost():C2}";
        }
    }
}
