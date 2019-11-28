using DesignPatterns.Singleton;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Singleton
{
    public class LazySingleton_Should
    {
        [Fact]
        public void Reference_Single_Instance()
        {
            var first = LazySingleton.Instance;
            var second = LazySingleton.Instance;
            Assert.Equal(first, second);
        }
    }
}
