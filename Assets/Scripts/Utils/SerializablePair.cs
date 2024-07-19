using System;

namespace Utils
{
    [Serializable]
    public class SerializablePair<T1, T2>
    {
        public T1 left;
        public T2 right;
    }
}