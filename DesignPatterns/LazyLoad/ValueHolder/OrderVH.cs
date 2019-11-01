using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.LazyLoad.ValueHolder
{
    public class OrderVH
    {
        public OrderVH(int id)
        {
            Id = id;
        }

        public int Id { get; }

        public ValueHolder<List<OrderItem>>? ItemsHolder { get; private set; }

        public List<OrderItem> Items => ItemsHolder?.Value ?? throw new InvalidOperationException();

        internal void SetItems(ValueHolder<List<OrderItem>> valueHolder) => ItemsHolder = valueHolder;
    }
}
