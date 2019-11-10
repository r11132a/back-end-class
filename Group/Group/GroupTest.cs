using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Group
{
    public class GroupTest
    {

        [Fact]
        public void Test_Add_One()
        {
            Group<int> g = new Group<int>();
            g.Add(1);
            int[] expected = { 1 };
            Assert.Equal(expected, g.ToArray());
        }

        [Fact]
        public void Test_Add_Several()
        {
            Group<int> g = new Group<int>();
            g.Add(1);
            g.Add(3);
            g.Add(2);
            int[] expected = { 1, 3, 2 };
            Assert.Equal(expected, g.ToArray());
        }

        [Fact]
        public void Test_Add_Existing()
        {
            Group<int> g = new Group<int>();
            g.Add(1);
            g.Add(1);

            int[] expected = { 1 };
            Assert.Equal(expected, g.ToArray());
        }

        [Fact]
        public void Test_Delete_one()
        {
            Group<int> g = new Group<int>();
            g.Add(1);
            g.Delete(1);
            Assert.False(g.Has(1));
        }

        [Fact]
        public void Test_Delete_Front()
        {
            Group<int> g = new Group<int>();
            g.Add(1);
            g.Add(2);
            g.Add(3);
            g.Delete(1);

            int[] expected = { 2, 3 };
            Assert.Equal(expected, g.ToArray())
;
        }

        [Fact]
        public void Test_Delete_End()
        {
            Group<int> g = new Group<int>();
            g.Add(1);
            g.Add(2);
            g.Add(3);

            g.Delete(3);
            int[] expected = { 1, 2 };

            Assert.Equal(expected, g.ToArray());
        }

        [Fact]
        public void Test_Delete_Middle()
        {
            Group<int> g = new Group<int>();

            for (int i = 1; i <= 10; i++)
            {
                g.Add(i);
            }

            g.Delete(3);

            int[] expected = { 1, 2, 4, 5, 6, 7, 8, 9, 10 };

            Assert.Equal(expected, g.ToArray());
        }

        [Fact]
        public void Test_CreateFromCollection()
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5 };

            Group<int> g = Group<int>.CreateFromCollection(list);

            int[] expected = { 1, 2, 3, 4, 5 };
            Assert.Equal(expected, g.ToArray());
        }
    }
}
