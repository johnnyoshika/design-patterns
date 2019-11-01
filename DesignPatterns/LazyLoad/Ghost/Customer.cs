using System;
using System.Collections;

namespace DesignPatterns.LazyLoad.Ghost
{
    public class Customer : DomainObject
    {
        public Customer(int id) : base(id)
        {
        }

        public string? Name { get; set; }

        protected override void DoLoadLine(ArrayList dataRow) => throw new NotImplementedException();

        protected override ArrayList GetDataRow() => throw new NotImplementedException();
    }
}
