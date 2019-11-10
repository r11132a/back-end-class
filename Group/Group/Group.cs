using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group
{
    public class Group<T>
    {
        private T[] _data = null;
        private int _count = 0;

        private const int DEFAULT_SIZE = 10;

        public Group(int startingSize = DEFAULT_SIZE)
        {
            _data = new T[startingSize];
        }

        public bool Has(T item) => Array.IndexOf<T>(_data, item) == -1 ? false : true;

        public void Add(T item)
        {
            if (!Has(item))
                Insert(item);
        }

        public void Delete(T item)
        {
            int index = Array.IndexOf<T>(_data, item);
            if (index == -1) return; // Don't have it, just do nothing.
            if (index == 0) // At the beginning
            {
                T[] temp = new T[_count - 1];
                Array.ConstrainedCopy(_data, 1, temp, 0, _count - 1);
                _data = temp;
            }
            else if (index == _count - 1) // At the end
            {
                Array.Resize(ref _data, _count - 1);
            }
            else // Somewhere in the middle
            {
                T[] temp = new T[_count - 1];
                Array.ConstrainedCopy(_data, 0, temp, 0, index); // Copy the first part
                Array.ConstrainedCopy(_data, index + 1, temp, index, _count - index - 1); // Copy the rest
                _data = temp;
            }
            _count--;
        }

        /// <summary>
        /// Returns a copy of the underlying array, sized to the count
        /// </summary>
        /// <returns>T[]</returns>
        public T[] ToArray()
        {
            T[] temp = new T[_count];

            Array.ConstrainedCopy(_data, 0, temp, 0, _count);

            return temp;
        }

        public static Group<T> CreateFromCollection(IEnumerable<T> collection)
        {
            Group<T> g = new Group<T>();
            foreach(var item in collection)
            {
                g.Add(item);
            }

            return g;
        }


        private void Insert(T item)
        {
            if(++_count > _data.Length)
            {
                Array.Resize(ref _data, _data.Length + DEFAULT_SIZE);
            }
            _data[_count - 1] = item;
        }
    }
}
