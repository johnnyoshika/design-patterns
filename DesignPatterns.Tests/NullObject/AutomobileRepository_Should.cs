using DesignPatterns.NullObject;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.NullObject
{
    public class AutomobileRepository_Should
    {
        [Fact]
        public void Return_Concrete_Automobile()
        {
            var auto = new AutomobileRepository().FindById("mini");

            Assert.NotEqual(Automobile.Null, auto);
            Assert.Equal("Mini Start", auto.Start());
            Assert.Equal("Mini Stop", auto.Stop());
        }

        [Fact]
        public void Return_Null_Object_When_Not_Found()
        {
            var auto = new AutomobileRepository().FindById("foo");

            Assert.Equal(Automobile.Null, auto);
            Assert.Empty(auto.Start());
            Assert.Empty(auto.Stop());
        }
    }
}
