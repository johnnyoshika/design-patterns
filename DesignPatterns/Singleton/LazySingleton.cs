using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Singleton
{
    public class LazySingleton
    {
        LazySingleton()
        {
        }

        // This is thread safe.
        public static LazySingleton Instance => Nested.instance;

        public void DoSomething()
        {
        }

        class Nested
        {
            // C# compiler will ensure that type initializer is instantiated lazily when there's a static constructor.
            static Nested()
            {
            }

            internal static readonly LazySingleton instance = new LazySingleton();
        }
    }
}
