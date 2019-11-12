using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.NullObject
{
    public abstract class Automobile
    {
        public abstract string Id { get; }
        public abstract string Name { get; }
        public abstract string Start();
        public abstract string Stop();

        public static readonly Automobile Null = new NullAutomobile();

        class NullAutomobile : Automobile
        {
            public override string Id => "";

            public override string Name => "";

            public override string Start() => "";

            public override string Stop() => "";
        }
    }

    public class MiniCooper : Automobile
    {
        public override string Id => "m1";
        public override string Name => "Mini Cooper";

        public override string Start() => "Mini Start";

        public override string Stop() => "Mini Stop";
    }
}
