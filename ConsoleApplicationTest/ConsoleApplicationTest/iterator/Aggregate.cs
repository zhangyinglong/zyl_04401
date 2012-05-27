using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplicationTest.iterator
{
    public interface ICreateTerator
    {
        Iterator CreateTerator();
    }

    class Aggregate : ICreateTerator
    {
        private int[] _array;

        public Aggregate(int[] array)
        {
            this._array = array;
        }

        public Iterator CreateTerator()
        {
            object[] o_array = new object[this._array.Length];
            for (int i = 0; i < this._array.Length; i++)
            {
                o_array[i] = this._array[i];//装箱
            }
            return new ArrayIterator(o_array);
        }
    }
}
