using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Iterator
{
    public class DemoTree<T> : IEnumerable<T>
    {
        public DemoTree(T value)
        {
            Value = value;
        }

        public T Value { get; }
        public DemoTree<T>? LeftChild { get; set; }
        public DemoTree<T>? RightChild { get; set; }

        public void Add(T value)
        {
            if (LeftChild == null)
            {
                LeftChild = new DemoTree<T>(value);
                return;
            }

            if (RightChild == null)
            {
                RightChild = new DemoTree<T>(value);
                return;
            }

            if (LeftChild.Depth() <= RightChild.Depth())
            {
                LeftChild.Add(value);
                return;
            }

            RightChild.Add(value);
        }

        public int Depth()
        {
            if (LeftChild == null || RightChild == null)
                return 0;

            return 1 + Math.Max(LeftChild.Depth(), RightChild.Depth());
        }

        public IEnumerable<DemoTree<T>> Children()
        {
            if (LeftChild != null)
                yield return LeftChild;

            if (RightChild != null)
                yield return RightChild;

            yield break;
        }

        public List<T> ToList()
        {
            var list = new List<T>();
            list.Add(Value);

            if (LeftChild != null)
                list.AddRange(LeftChild.ToList());

            if (RightChild != null)
                list.AddRange(RightChild.ToList());

            return list;
        }

        public IEnumerator<T> GetEnumerator() => new DemoTreeEnumerator<T>(this);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public override string ToString() => Value?.ToString() ?? "NULL";
    }
}
