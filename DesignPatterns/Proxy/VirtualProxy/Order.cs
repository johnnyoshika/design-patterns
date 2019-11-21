using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Proxy.VirtualProxy
{
    /*
    Similar example is in LazyLoad/VirtualProxy
    */
    public class Order
    {
        internal Order(ICustomerRepository customerRepository)
        {
            CustomerRepository = customerRepository;
        }

        public Order(ICustomerRepository customerRepository, int id, int customerId) : this(customerRepository)
        {
            Id = id;
            CustomerId = customerId;
            Customer = GetCustomer();
        }

        ICustomerRepository CustomerRepository { get; }

        public int Id { get; protected set; }
        public int CustomerId { get; protected set; }
        public virtual Customer? Customer { get; set; }

        protected virtual Customer GetCustomer() => CustomerRepository.GetById(CustomerId);
    }

    public class OrderProxy : Order
    {
        public OrderProxy(ICustomerRepository customerRepository, int id, int customerId) : base(customerRepository)
        {
            Id = id;
            CustomerId = customerId;
        }

        Customer? _customer;
        public override Customer Customer { get => GetCustomer(); } // Note: we could use .Net's Lazy<T> for this. See DesignPatterns.LazyLoad.LazyInitialization.OrderLazy.

        protected override Customer GetCustomer()
        {
            if (_customer == null)
                _customer = base.GetCustomer();

            return _customer;
        }
    }
}
