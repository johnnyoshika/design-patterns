using DesignPatterns.EventAggregator;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.EventAggregator
{
    public class SimpleEventAggregator_Should
    {
        [Fact]
        public void Publish_OrderCreated_Event_ToSubscribers()
        {
            var ea = new SimpleEventAggregator();

            var order = new Order { Id = 1 };

            new OrderView(ea);
            ea.Publish(new OrderCreated(order));

            Assert.Contains("OrderCreated", order.Messages);
            Assert.Single(order.Messages);
        }

        [Fact]
        public void Publish_OrderCreated_And_OrderSelected_Event_ToSubscribers()
        {
            var ea = new SimpleEventAggregator();

            var order = new Order { Id = 1 };

            new OrderView(ea);
            ea.Publish(new OrderCreated(order));
            ea.Publish(new OrderSelected(order));

            Assert.Contains("OrderCreated", order.Messages);
            Assert.Contains("OrderSelected", order.Messages);
            Assert.Equal(2, order.Messages.Count);
        }

        [Fact]
        public void Allow_Multiple_Instances_To_Aggregate_Independently()
        {
            var ea0 = new SimpleEventAggregator();

            var order0 = new Order { Id = 1 };

            new OrderView(ea0);
            ea0.Publish(new OrderCreated(order0));

            Assert.Single(order0.Messages);
            Assert.Contains("OrderCreated", order0.Messages);


            var ea1 = new SimpleEventAggregator();

            var order1 = new Order { Id = 1 };

            new OrderView(ea1);
            ea1.Publish(new OrderCreated(order1));
            ea1.Publish(new OrderSelected(order1));

            Assert.Equal(2, order1.Messages.Count);
            Assert.Contains("OrderCreated", order1.Messages);
            Assert.Contains("OrderSelected", order1.Messages);
        }
    }

    public class OrderView : ISubscriber<OrderCreated>, ISubscriber<OrderSelected>
    {
        public OrderView(IEventAggregator ea)
        {
            ea.Subscribe(this);
        }

        public void OnEvent(OrderCreated e) => e.Order.Messages.Add("OrderCreated");

        public void OnEvent(OrderSelected e) => e.Order.Messages.Add("OrderSelected");
    }
}
