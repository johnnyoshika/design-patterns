using DesignPatterns.LazyLoad.LazyInitialization;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.LazyLoad
{
    public class OrderLazy_Should
    {
        [Fact]
        public void Lazy_Initialize_Customer()
        {
            var order = new OrderLazy();
            Assert.Equal("ABC: 123 Blvd", order.PrintLabel());
        }
    }
}
