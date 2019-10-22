using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors
{
    public class Vector
    {
        // Fields
        double _i = 0, _j = 0;

        // Constructors
        public Vector() { }
        public Vector(double i, double j)
        {
            _i = i;
            _j = j;
        }

        // Properties
        public double Magnitude
        {
            get => Math.Sqrt(Math.Pow(_i, 2) + Math.Pow(_j, 2));
        }

        public double Direction
        {
            get => Math.Atan2(_j, _i);
        }

        // Public Methods
        public Vector Add(Vector v1) => new Vector(_i + v1._i, _j + v1._j);

        public Vector Subtract(Vector v1) => new Vector(_i - v1._i, _j - v1._j);

        public bool Equals(Vector v1) => (v1 != null && _i == v1._i && _j == v1._j);

        public override bool Equals(object obj) => obj is Vector v && Equals(v);
    }
}
