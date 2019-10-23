using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.EventAggregator
{
    public class OrderCreated
    {
        public OrderCreated(Order order) => Order = order;
        public Order Order { get; }
    }

    public class OrderSelected
    {
        public OrderSelected(Order order) => Order = order;
        public Order Order { get; }
    }

    public class OrderSaved
    {
        public OrderSaved(Order order) => Order = order;

        public Order Order { get; }
    }
}
