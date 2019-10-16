using DesignPatterns.Builder.Director;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Builder.Director
{
    public class SandwichMaker_Should
    {
        [Fact]
        public void Make_Ham_Sandwich()
        {
            var builder = new HamSandwichBuilder();
            var maker = new SandwichMaker(builder);
            maker.Build();
            var sandwich = maker.GetSandwich();
            Assert.Equal("Toasted: True | Mustard: True | Mayo: False | Meat: Ham | Cheese: Swiss", sandwich.ToString());
        }

        [Fact]
        public void Make_Turkey_Sandwich()
        {
            var builder = new TurkeySandwichBuilder();
            var maker = new SandwichMaker(builder);
            maker.Build();
            var sandwich = maker.GetSandwich();
            Assert.Equal("Toasted: True | Mustard: False | Mayo: True | Meat: Turkey | Cheese: Cheddar", sandwich.ToString());
        }
    }
}
