using DesignPatterns.LazyLoad.VirtualProxy;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.LazyLoad
{
    public class OrderProxy_Should
    {
        [Fact]
        public void Use_Virtual_Proxy_To_Lazy_Load_Customer()
        {
            int testOrderId = 123;
            var order = new OrderFactory().Create(testOrderId);

            Assert.Equal(testOrderId, order.Id); // should not have constructed Customer at this point

            Assert.Equal("ABC: 123 Blvd", order.PrintLabel());
        }
    }
}
