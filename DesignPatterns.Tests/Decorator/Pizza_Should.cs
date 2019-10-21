using DesignPatterns.Decorator;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Decorator
{
    public class Pizza_Should
    {
        /*
        When to use Decorator pattern:
        - Legacy systems
        - Add functionality to UI controls
        - Sealed classes

        AKA: Wrapper Pattern
        */

        [Fact]
        public void Get_Description_And_Calculate_Cost()
        {
            Pizza largePizza = new LargePizza();

            Assert.Equal("Large Pizza", largePizza.GetDescription());
            Assert.Equal(9, largePizza.CalculateCost());
        }

        [Fact]
        public void Allow_Being_Decorated_With_Cheese()
        {
            Pizza largePizza = new LargePizza();
            largePizza = new Cheese(largePizza);

            Assert.Equal("Large Pizza, Cheese", largePizza.GetDescription());
            Assert.Equal(10.25m, largePizza.CalculateCost());
        }

        [Fact]
        public void Allow_Being_Decorated_With_Cheese_And_Ham()
        {
            Pizza largePizza = new LargePizza();
            largePizza = new Cheese(largePizza);
            largePizza = new Ham(largePizza);

            Assert.Equal("Large Pizza, Cheese, Ham", largePizza.GetDescription());
            Assert.Equal(11.25m, largePizza.CalculateCost());
        }

        [Fact]
        public void Allow_Being_Decorated_With_Cheese_And_Ham_And_Peppers()
        {
            Pizza largePizza = new LargePizza();
            largePizza = new Cheese(largePizza);
            largePizza = new Ham(largePizza);
            largePizza = new Peppers(largePizza);

            Assert.Equal("Large Pizza, Cheese, Ham, Peppers", largePizza.GetDescription());
            Assert.Equal(13.25m, largePizza.CalculateCost());
        }
    }
}
