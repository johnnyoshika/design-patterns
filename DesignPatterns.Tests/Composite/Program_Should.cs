using DesignPatterns.Composite;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Composite
{
    public class Program_Should
    {
        /*
        Composite pattern composes objects into tree structures to represent part-hole hierarchies.

        Our example:
        - IParty is the Component
        - Group is the Composite
        - Person is the Leaf

        When to use:
        - Groups and collections
        - Trees
        - Distribution (e.g. distribute gold to parties as in our example below)
        */

        [Fact]
        public void Use_Tree_To_Split_Gold_Equally_Among_People()
        {
            var party = new Group
            {
                Members = new List<IParty>
                {
                    new Person("Mary"),
                    new Person("Bob")
                }
            };
            var result = Program.Run(100, party);
            Assert.Equal("Mary has 50 gold coins.\nBob has 50 gold coins.", result);
        }

        [Fact]
        public void Use_Tree_To_Mostly_Split_Gold_Equally_When_Unevenly_Splittable_Coins()
        {
            var party = new Group
            {
                Members = new List<IParty>
                {
                    new Person("Mary"),
                    new Person("Bob")
                }
            };
            var result = Program.Run(101, party);
            Assert.Equal("Mary has 51 gold coins.\nBob has 50 gold coins.", result);
        }

        [Fact]
        public void Use_Tree_To_Split_Gold_Equally_Among_Groups()
        {
            var party = new Group
            {
                Members = new List<IParty>
                {
                    new Person("Mary"),
                    new Person("Bob"),
                    new Group
                    {
                        Members = new List<IParty>
                        {
                            new Person("Jane"),
                            new Group
                            {
                                Members = new List<IParty>
                                {
                                    new Person("Kim"),
                                    new Person("Garth")
                                }
                            }
                        }
                    }
                }
            };
            var result = Program.Run(300, party);
            Assert.Equal("Mary has 100 gold coins.\nBob has 100 gold coins.\nJane has 50 gold coins.\nKim has 25 gold coins.\nGarth has 25 gold coins.", result);
        }
    }
}
