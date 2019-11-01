using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.LazyLoad.VirtualProxy
{
    // Challenge with Virtual Proxy is identity between Order and OrderProxy. We need a hack to get around that.
    public class Order
    {
        public int Id { get; set; }
        public virtual Customer? Customer { get; set; }

        public string PrintLabel() => $"{Customer?.Name}: {Customer?.Address}";

        public override int GetHashCode() => Id.GetHashCode();
    }

    public class OrderProxy : Order
    {
        public override Customer? Customer
        {
            get 
            {
                if (base.Customer == null)
                    base.Customer = new Customer();

                return base.Customer;
            }
            set => base.Customer = value;
        }

        // ensure equality works whether we're comparing against Order or OrderProxy
        public override bool Equals(object? obj)
        {
            var other = obj as Order;
            if (other == null) return false;
            return other.Id == Id;
        }

        public override int GetHashCode() => base.GetHashCode();
    }

    public class OrderFactory
    {
        public Order Create(int id) => new OrderProxy { Id = id };
    }

    public class Customer
    {
        public Customer()
        {
            Name = "ABC";
        }

        public string Name { get; }
        public string Address => "123 Blvd";
    }
}
