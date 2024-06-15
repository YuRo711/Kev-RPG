using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Utils
{
    public class ShiftingArray<T>
    {
        private readonly T[] _array;

        public ShiftingArray(int lengthLimit)
        {
            _array = new T[lengthLimit];
        }

        public void ShiftRight(T element) 
        {
            for (int i = _array.Length - 1; i > 0; i--) 
            {
                _array[i] = _array[i - 1];
            }

            _array[0] = element;
        }


        public T this[int index]
        {
            get
            {
                if(index > _array.Length - 1)
                {
                    throw new IndexOutOfRangeException();
                }

                return _array[index];
            }
        }
    }
}