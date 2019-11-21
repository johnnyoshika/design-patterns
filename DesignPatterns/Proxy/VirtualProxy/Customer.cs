using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Proxy.VirtualProxy
{
    public class Customer
    {
        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; }
        public string Name { get; }
    }

    public interface ICustomerRepository
    {
        Customer GetById(int id);
    }
}
