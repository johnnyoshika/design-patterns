using DesignPatterns.LazyLoad.Ghost;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.LazyLoad
{
    public class Order_Ghost_Should
    {
        protected class TestOrderWrapper : Order
        {
            public bool WasLoadCalled = false;
            public int GetDataRowCount = 0;

            public TestOrderWrapper(int id) : base(id)
            {
            }

            public override void Load()
            {
                WasLoadCalled = true;
                base.Load();
            }

            protected override ArrayList GetDataRow()
            {
                GetDataRowCount++;
                return base.GetDataRow();
            }
        }

        [Fact]
        public void Load_Itself_Only_Once_On_Property_Access()
        {
            int orderId = 123;
            var order = new TestOrderWrapper(orderId);

            Assert.Equal(orderId, order.Id);
            Assert.False(order.WasLoadCalled);
            Assert.Equal(0, order.GetDataRowCount);

            // should call Load and GetDataRow once
            var shipMethod = order.ShipMethod;
            Assert.True(order.WasLoadCalled);
            Assert.Equal(1, order.GetDataRowCount);
            Assert.Equal("FEDEX", shipMethod);

            // should not increment GetDataRowCount
            var customer = order.Customer;
            Assert.True(order.WasLoadCalled);
            Assert.Equal(1, order.GetDataRowCount);
        }

        [Fact]
        public void Load_Items_In_Single_Call_On_Property_Access()
        {
            int orderId = 123;
            var order = new Order(orderId);

            int itemCount = order.Items.Count(); // should call repository here

            Assert.Equal(2, itemCount);
        }
    }
}
