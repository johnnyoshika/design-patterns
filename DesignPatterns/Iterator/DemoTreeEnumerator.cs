using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPatterns.Iterator
{
    /// <summary>
    /// Uses depth first tree structure
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class DemoTreeEnumerator<T> : IEnumerator<T>
    {
        DemoTree<T> Tree { get; }
        DemoTree<T>? _Current { get; set; }
        DemoTree<T>? Previous { get; set; }
        Stack<DemoTree<T>?> Breakcrumb { get; } = new Stack<DemoTree<T>?>();

        public DemoTreeEnumerator(DemoTree<T> tree)
        {
            Tree = tree;
        }

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (_Current == null)
            {
                Reset();
                _Current = Tree;
                return true;
            }

            if (_Current.LeftChild != null)
                return TraverseLeft();

            if (_Current.RightChild != null)
                return TraverseRight();

            return TraverseUpAndRight();
        }

        bool TraverseUpAndRight()
        {
            if (Breakcrumb.Count > 0)
            {
                Previous = _Current;
                while(true)
                {
                    _Current = Breakcrumb.Pop();
                    if (Previous != _Current!.RightChild) break;
                }
                
                if (_Current?.RightChild != null)
                {
                    Breakcrumb.Push(_Current);
                    _Current = _Current.RightChild;
                    return true;
                }
            }
            return false;
        }

        bool TraverseLeft()
        {
            Breakcrumb.Push(_Current);
            _Current = _Current!.LeftChild;
            return true;
        }

        bool TraverseRight()
        {
            Breakcrumb.Push(_Current);
            _Current = _Current!.RightChild;
            return true;
        }

        public void Reset() => _Current = null;

        public T Current => _Current == null ? throw new InvalidOperationException() : _Current.Value;

        object? IEnumerator.Current => Current;
    }
}