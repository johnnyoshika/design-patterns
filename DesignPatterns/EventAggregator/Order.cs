using System.Collections.Generic;

namespace DesignPatterns.EventAggregator
{
    public class Order
    {
        public int Id { get; set; }
        public List<string> Messages { get; } = new List<string>();
    }
}
