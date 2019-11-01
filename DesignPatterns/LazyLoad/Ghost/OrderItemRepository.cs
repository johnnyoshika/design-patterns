using System;
using System.Collections.Generic;

namespace DesignPatterns.LazyLoad.Ghost
{
    internal class OrderItemRepository
    {
        public IEnumerable<OrderItem> ItemsForOrder(int id) =>
            id == 1
            ? new List<OrderItem>
                {
                    new OrderItem { Quantity = 2, Description = "Car" },
                    new OrderItem { Quantity = 1, Description = "Plane" }
                }
            : new List<OrderItem>
                {
                    new OrderItem { Quantity = 20, Description = "Chips" },
                    new OrderItem { Quantity = 10, Description = "Salsa" }
                };
    }
}