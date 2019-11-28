using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

using SL = DesignPatterns.ServiceLocator.ServiceLocator;

namespace DesignPatterns.Tests.ServiceLocator
{
    public class ServiceLocator_Should
    {
        [Fact]
        public void Locate_Service()
        {
            var myTalker = new Mock<ITalker>();
            myTalker.Setup(t => t.Speak()).Returns("Hi!");

            SL.AddService("talker", myTalker.Object);

            var talker = SL.GetService<ITalker>("talker");
            Assert.Equal("Hi!", talker.Speak());
        }
    }

    public interface ITalker
    {
        string Speak();
    }
}
