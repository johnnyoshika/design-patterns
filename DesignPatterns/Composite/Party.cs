using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Composite
{
    public interface IParty
    {
        int Gold { get; set; }
        string Stats();
    }

    public class Person : IParty
    {
        public Person(string name) => Name = name;

        public string Name { get; set; }
        public int Gold { get; set; }

        public string Stats() =>
            $"{Name} has {Gold} gold coins.";
    }

    public class Group : IParty
    {
        public List<IParty> Members { get; set; } = new List<IParty>();

        public int Gold
        {
            get => Members.Sum(m => m.Gold);
            set
            {
                var eachSplit = value / Members.Count;
                var leftOver = value % Members.Count;
                foreach (var member in Members)
                {
                    member.Gold += eachSplit + leftOver;
                    leftOver = 0;
                }
            }
        }

        public string Stats() =>
            string.Join("\n", Members.Select(m => m.Stats()));
    }
}
