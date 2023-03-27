using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] input = Console.ReadLine().Split().ToArray();
            Queue<string> songs2 = new Queue<string>(Console.ReadLine().Split(", ").ToArray());

            //Queue<string> songs = new Queue<string>(input);

            while (songs2.Count > 0)
            {

                string input2 = Console.ReadLine();

                if (input2 == "Play")
                {
                    songs2.Dequeue();
                }
                else if (input2 == "Show")
                {
                    Console.WriteLine(string.Join(", ", songs2));
                }
                else if (input2.StartsWith("Add"))
                {
                    int startindex = input2.IndexOf(' ');
                    string song = input2.Substring(startindex + 1);

                    if (!songs2.Contains(song))
                    {
                        songs2.Enqueue(song);
                    }
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }

                }




                //  1st WAY!!!!    string srinput = Console.ReadLine();

                //string[] input2 = srinput.Split();

                //if (input2[0] == "Play")
                //{
                //    songs2.Dequeue();
                //}
                //else if (input2[0] == "Add")
                //{
                //    int startIndex = srinput.IndexOf(' ');
                //    string song = srinput.Substring(startIndex +1 , srinput.Length - (startIndex + 1));

                //    if (!songs2.Contains(song))
                //    {
                //        songs2.Enqueue(song);
                //    }
                //    else
                //    {
                //        Console.WriteLine($"{song} is already contained!");
                //    }

                //}
                //else if (input2[0] == "Show")
                //{
                //    Console.WriteLine(string.Join(", ", songs2));
                //}

            }

            Console.WriteLine("No more songs!");


        }
    }
}
