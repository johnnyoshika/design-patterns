using System;

namespace DesignPatterns.Repository
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime HiredOn { get; set; }
    }
}
