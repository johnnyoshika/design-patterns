using DesignPatterns.Builder.Simple;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Builder.Simple
{
    // This doesn't adhere to the true Builder Pattern, as it doesn't use a Director

    public class SandwichBuilder_Should
    {
        [Fact]
        public void Build_Ham_Sandwich()
        {
            var builder = new HamSandwichBuilder();
            var sandwich = builder.Build();
            Assert.Equal("Toasted: True | Mustard: True | Mayo: False | Meat: Ham | Cheese: Swiss", sandwich.ToString());
        }

        [Fact]
        public void Build_Turkey_Sandwich()
        {
            var builder = new TurkeySandwichBuilder();
            var sandwich = builder.Build();
            Assert.Equal("Toasted: True | Mustard: False | Mayo: True | Meat: Turkey | Cheese: Cheddar", sandwich.ToString());
        }
    }
}
