using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            int[] arr = ArrayCreator.Create<int>(5, 6);

            string[] strArr = ArrayCreator.Create(5, "hope");

            Console.WriteLine(String.Join(" ", arr));
            Console.WriteLine(String.Join(" ", strArr));



        }
    }
}
