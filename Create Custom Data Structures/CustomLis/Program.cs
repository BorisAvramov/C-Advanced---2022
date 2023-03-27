using System;

namespace CustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {

            CustomList customList = new CustomList();

            //            void Add(int element) -Adds the given element to the end of the list
            customList.Add(1);
            customList.Add(2);
            customList.Add(3);
            customList.Add(4);

            //Console.WriteLine(customList[0]);
            //Console.WriteLine(customList[1]);
            //Console.WriteLine(customList[2]);
            //Console.WriteLine(customList[3]); //throw new IndexOutOfRangeException();

            //Console.WriteLine(customList[0] = 5); // change value /SET VALUE/

            customList.Insert(1, 6);


            Console.WriteLine(customList.RemoveAt(1));


            for (int i = 0; i < customList.Count; i++)
            {
                Console.WriteLine(customList[i]);
            }

            Console.WriteLine(customList.Contains(5));

            customList.Swap(0, 1);

            for (int i = 0; i < customList.Count; i++)
            {
                Console.WriteLine(customList[i]);
            }





        }
    }
}
