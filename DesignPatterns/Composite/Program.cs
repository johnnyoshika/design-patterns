using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Composite
{
    public static class Program
    {
        public static string Run(int totalGold, IParty party)
        {
            party.Gold += totalGold;
            return party.Stats();
        }
    }
}
