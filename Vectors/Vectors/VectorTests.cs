using Xunit;

namespace Vectors
{
    public class VectorTests
    {
        [Fact]
        public void TestAddVectors()
        {
            Vector v1 = new Vector(2, 1);
            Vector v2 = new Vector(3, 4);

            Vector expected = new Vector(5, 5);
            Assert.Equal(expected, v1.Add(v2));
        }

        [Fact]
        public void TestSubtractVectors()
        {
            Vector v1 = new Vector(3, 4);
            Vector v2 = new Vector(2, 1);

            Vector expected = new Vector(1, 3);

            Assert.Equal(expected, v1.Subtract(v2));
        }

        [Fact]
        public void TestMagnitude()
        {
            Vector v1 = new Vector(3, 4);

            double expected = 5.0;

            Assert.Equal(expected, v1.Magnitude);
        }

        [Fact]
        public void TestDirection()
        {
            Vector v1 = new Vector(3, 4);

            double expected_high = 0.9337511;
            double expected_low = 0.9162979;

            Assert.InRange<double>(v1.Direction, expected_low, expected_high);
        }
    }
}
