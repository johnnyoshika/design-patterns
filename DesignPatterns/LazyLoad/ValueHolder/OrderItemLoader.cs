using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.LazyLoad.ValueHolder
{
    public class OrderItemLoader : IValueLoader<List<OrderItem>>
    {
        public OrderItemLoader(int orderId)
        {
            OrderId = orderId;
        }

        int OrderId { get; }

        public List<OrderItem> Load()
        {
            // pretend we're fetching items from the database
            return new List<OrderItem>();
        }
    }
}
