using System;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<int> myBox = new Box<int>();

            myBox.Add(1);
            myBox.Add(2);
            myBox.Add(3);
            myBox.Add(4);

            Console.WriteLine(myBox.Remove());
            myBox.Add(4);
            myBox.Add(5);
            Console.WriteLine(myBox.Remove());


        }
    }
}
