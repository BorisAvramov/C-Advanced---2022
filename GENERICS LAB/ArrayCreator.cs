using System.Collections.Generic;
using System.IO;

namespace GenericsDemo
{
    public static class ArrayCreator
    {
        public static T[] Create<T>(int lenght)
            where T : Stream, new()
        {
            T[] array = new T[lenght];
            for (int i = 0; i < lenght; i++)
            {
                array[i] = new T();
            }

            return array;
        }
    }
}
