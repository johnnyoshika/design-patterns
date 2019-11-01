using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.LazyLoad.Ghost
{
    // In Ghost, the object is its own virtual proxy and it loads all of its missing state from persistence when one is requested.
    // However, it does violate the Single Responsibility Principle
    public class Order : DomainObject
    {
        public Order(int id) : base(id)
        {
        }

        string? _shipMethod;
        public string? ShipMethod
        {
            get
            {
                Load();
                return _shipMethod;
            }
            set
            {
                Load();
                _shipMethod = value;
            }
        }

        Customer? _customer;
        public Customer? Customer
        {
            get
            {
                Load();
                return _customer;
            }
            set
            {
                Load();
                _customer = value;
            }
        }

        Lazy<List<OrderItem>>? _items;
        public IEnumerable<OrderItem> Items
        {
            get
            {
                Load();
                return _items?.Value.AsReadOnly() ?? throw new InvalidOperationException();
            }
        }

        protected override void DoLoadLine(ArrayList dataRow)
        {
            ShipMethod = (string)(dataRow[0] ?? "");
            Customer = new Customer((int)(dataRow[1] ?? throw new ArgumentNullException())); // this customer is also a ghost type
            _items = new Lazy<List<OrderItem>>(() => new OrderItemRepository().ItemsForOrder(Id).ToList());
        }

        // simulate fetching a DataRow via DataReader
        protected override ArrayList GetDataRow()
        {
            var row = new ArrayList();
            row.Add("FEDEX"); // ship method
            row.Add(123); // customer id
            return row;
        }
    }

    public class OrderItem
    {
        public int Quantity { get; set; }
        public string? Description { get; set; }
    }
}
