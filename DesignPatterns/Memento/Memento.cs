using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatterns.Memento
{
    // Most common use case: undo/redo stack
    // 3 components:
    // - The originator represents the object whose state is being tracked (Canvas in our example below)
    // - The caretaker performs operations on the originator and needs to be able to undo the operations (Window in our example below)
    // - The memento is a value object that holds the state of the originator (CanvasMemento in our example below)
    public class Window
    {
        public Window() => StoreState();

        Stack<IMemento> States { get; } = new Stack<IMemento>();
        public Canvas Canvas { get; } = new Canvas();

        public void StoreState() => States.Push(Canvas.CreateMemento());

        public void Undo()
        {
            if (States.Count > 1)
            {
                // discard current stats
                States.Pop();
                Canvas.SetMemento(States.Peek());
            }
        }

        public string Print() => string.Join('|', Canvas.Strokes);

        public int StateCount => States.Count;
    }

    public interface IMemento
    {
        object State { get; }
    }

    public class Canvas
    {
        public List<string> Strokes { get; set; } = new List<string>();

        public IMemento CreateMemento() => new CanvasMemento(Strokes.ToArray() /* creates a copy */);

        public void SetMemento(IMemento memento) => Strokes = ((string[])memento.State).ToList();

        public class CanvasMemento : IMemento
        {
            public CanvasMemento(object state) => State = state;
            public object State { get; }
        }
    }
}
