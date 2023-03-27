using System;

namespace minValue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int []{ 1, 5, 16, 56 };

            int minValue = int.MaxValue;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < minValue)
                {
                    minValue = arr[i];
                }


            }
            Console.WriteLine(minValue);
        }
    }
}
