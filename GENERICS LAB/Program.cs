using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GenericsDemo
{
    class Pair<T>
    {
        public Pair()
        {

        }

        public T First { get; set; }

        public T Second { get; set; }
    }

    class TypeWithConstructor
    {
        public TypeWithConstructor(int a)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Intelli code (ML)

            var pair = new Pair<string>();

            var list = new List<string>();

            var arrayStr = CreateArray(10, "Niki");
            var arrayStr2 = CreateArray(10, "Niki");
        }

        static T[] CreateArray<T>(int count, T element)
        {
            T[] result = new T[count];
            for (int i = 0; i < count; i++)
            {
                result[i] = element;
            }

            return result;
        }
    }
}
