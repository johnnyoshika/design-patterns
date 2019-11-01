using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.LazyLoad.ValueHolder
{
    public class OrderFactory
    {
        public OrderVH Create(int id)
        {
            var order = new OrderVH(id);

            // The factory decides how items are populated insetad of baking this in OrderVH itself
            order.SetItems(new ValueHolder<List<OrderItem>>(new OrderItemLoader(id)));
            return order;
        }
    }
}
