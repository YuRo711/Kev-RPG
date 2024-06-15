using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Utils
{
    public class ShiftingArray<T>
    {
        private readonly T[] _array;
        private readonly int _maxLength;
        public int MaxIndex { get; private set; }

        public ShiftingArray(int lengthLimit)
        {
            _array = new T[lengthLimit];
            _maxLength = lengthLimit;
            MaxIndex = 0;
        }

        public void ShiftRight(T element) 
        {
            for (int i = _maxLength - 1; i > 0; i--) 
            {
                _array[i] = _array[i - 1];
            }

            _array[0] = element;

            if (MaxIndex < _maxLength - 1)
                MaxIndex++;
        }


        public T this[int index]
        {
            get
            {
                if(index > _maxLength - 1)
                {
                    throw new IndexOutOfRangeException();
                }

                return _array[index];
            }
        }
    }
}