using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Builder.Director
{
    public class SandwichMaker
    {
        public SandwichMaker(SandwichBuilder builder)
        {
            Builder = builder;
        }

        SandwichBuilder Builder { get; }

        public void Build()
        {
            Builder.Toast();
            Builder.AddCondiments();
            Builder.ApplyMeat();
            Builder.ApplyCheese();
        }

        public Sandwich GetSandwich() => Builder.GetSandwich();
    }
}
