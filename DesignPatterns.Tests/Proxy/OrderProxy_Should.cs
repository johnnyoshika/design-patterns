using DesignPatterns.Proxy.VirtualProxy;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Proxy
{
    public class OrderProxy_Should
    {
        [Fact]
        public void Defer_Object_Population_Until_Access()
        {
            var customerRepository = new Mock<ICustomerRepository>();
            customerRepository.Setup(x => x.GetById(123)).Returns(new Customer(123, "ABC Company"));

            var order = new OrderProxy(customerRepository.Object, 1, 123);
            var customer = order.Customer;
            var customer2 = order.Customer;
            Assert.Equal("ABC Company", customer.Name);
            Assert.Equal("ABC Company", customer2.Name);

            customerRepository.Verify(x => x.GetById(It.IsAny<int>()), Times.Once());
        }
    }
}
