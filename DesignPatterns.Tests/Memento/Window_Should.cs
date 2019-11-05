using DesignPatterns.Memento;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Memento
{
    public class Window_Should
    {
        [Fact]
        public void Store_First_State()
        {
            var window = new Window();

            Assert.Equal(1, window.StateCount);
            Assert.Empty(window.Print());
        }

        [Fact]
        public void Store_Multiple_States_And_Undo()
        {
            var window = new Window();

            window.Canvas.Strokes.Add("horizontal line");
            window.StoreState();

            window.Canvas.Strokes.Add("vertical line");
            window.StoreState();

            window.Canvas.Strokes.Add("circle");
            window.StoreState();

            Assert.Equal(4, window.StateCount);
            Assert.Equal("horizontal line|vertical line|circle", window.Print());

            window.Undo();

            Assert.Equal(3, window.StateCount);
            Assert.Equal("horizontal line|vertical line", window.Print());

            window.Undo();

            Assert.Equal(2, window.StateCount);
            Assert.Equal("horizontal line", window.Print());

            window.Undo();

            Assert.Equal(1, window.StateCount);
            Assert.Empty(window.Print());
        }
    }
}
