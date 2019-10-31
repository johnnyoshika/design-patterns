using DesignPatterns.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DesignPatterns.Tests.Iterator
{
    public class DemoTree_Should
    {
        [Fact]
        public void Store_Value_In_Root_Node()
        {
            var tree = CreateTreeWithValues(1);
            Assert.Equal(1, tree?.Value);
        }

        [Fact]
        public void List_Values_In_Depth_First_Order_With_Enumerator()
        {
            /*
            Tree structure:

                    (1)
                   /   \
                 (2)   (3)
                /   \    \
              (4)   (5)  (6)

            */


            var tree = CreateTreeWithValues(6);
            var values = string.Join(" ", tree.ToArray());
            Assert.Equal("1 2 4 5 3 6", values);
        }

        DemoTree<int>? CreateTreeWithValues(int n)
        {
            if (n <= 0) return null;

            var tree = new DemoTree<int>(1);
            for (int i = 2; i <= n; i++)
                tree.Add(i);

            return tree;
        }
    }
}
