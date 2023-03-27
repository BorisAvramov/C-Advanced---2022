using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._The_Fight_for_Gondor
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int numWavesOrc = int.Parse(Console.ReadLine());


            //Queue<int> QueuePlatesDefence = new Queue<int>(Console.ReadLine()
            //     .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            //     .Select(int.Parse));

            LinkedList<int> QueuePlatesDefence = new LinkedList<int>(Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse));

            bool orcWin = false;
            bool aragornWint = false;

            List<int> warriors = new List<int>();

            for (int i = 1; i <= numWavesOrc; i++)
            {
               
                Stack<int> StackWavesOrc = new Stack<int>(Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse));
                if (i % 3 == 0)
                {

                    QueuePlatesDefence.AddLast(int.Parse(Console.ReadLine()));
                }

                while (QueuePlatesDefence.Count > 0 && StackWavesOrc.Count > 0)
                {

                    int curPlate = QueuePlatesDefence.ElementAt(0);
                    int curOrc = StackWavesOrc.Peek();

                    if (curPlate == curOrc)
                    {
                        QueuePlatesDefence.RemoveFirst();
                        StackWavesOrc.Pop();
                    }
                    if (curPlate > curOrc)
                    {
                        StackWavesOrc.Pop();
                        QueuePlatesDefence.RemoveFirst();
                        QueuePlatesDefence.AddFirst(curPlate - curOrc);
                    }
                    if (curPlate < curOrc)
                    {
                        QueuePlatesDefence.RemoveFirst();
                        StackWavesOrc.Pop();
                        StackWavesOrc.Push(curOrc - curPlate);

                    }
                }

                if (QueuePlatesDefence.Count == 0)
                {
                    warriors = StackWavesOrc.ToList() ;
                    orcWin = true;
                    break;
                }

                if (i == numWavesOrc && StackWavesOrc.Count == 0)
                {
                    aragornWint = true;
                    break;
                }


            }
            if (orcWin == true)
            {
                Console.WriteLine($"The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine(($"Orcs left: {string.Join(", ", warriors)}"));
            }
            if (aragornWint == true)
            {
                Console.WriteLine($"The people successfully repulsed the orc's attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", QueuePlatesDefence)}");
            }
        }
    }
}
