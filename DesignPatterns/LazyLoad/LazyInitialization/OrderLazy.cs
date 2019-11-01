using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.LazyLoad.LazyInitialization
{
    public class OrderLazy
    {
        // Lazy<T> defaults to thread safe - set isThreadSafe to false if not needed
        // We're just lazy instantiating a new Customer, but this is where real lazy loading would be done in a real application
        Lazy<Customer> CustomerInitializer { get; } = new Lazy<Customer>(() => new Customer());

        public Customer Customer => CustomerInitializer.Value;

        public string PrintLabel() => $"{Customer.Name}: {Customer.Address}";
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
