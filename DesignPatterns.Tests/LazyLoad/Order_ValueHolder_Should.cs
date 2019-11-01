using DesignPatterns.LazyLoad.ValueHolder;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.LazyLoad
{
    public class Order_ValueHolder_Should
    {
        [Fact]
        public void Not_Load_Items_Until_Referenced()
        {
            int orderId = 123;
            var order = new OrderFactory().Create(orderId);

            Assert.Equal(orderId, order.Id);

            var items = order.Items; // this should load load

            Assert.Empty(items);
        }
    }
}
