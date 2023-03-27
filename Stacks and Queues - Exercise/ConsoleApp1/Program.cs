﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int numPetrolPumps = int.Parse(Console.ReadLine());

            Queue<int[]> queuePetrolPumps = new Queue<int[]>();

            for (int i = 0; i < numPetrolPumps; i++)
            {
                int[] data = Console.ReadLine().Split().Select(int.Parse).ToArray();
                queuePetrolPumps.Enqueue(data);
            }

            int startindex = 0;
            bool reched = true;
            while (true)
            {

                int totalAmount = 0;

                foreach (var item in queuePetrolPumps)
                {
                    int curAmount = item[0];
                    int curDistance = item[1];
                    totalAmount += curAmount;
                    if (totalAmount >= curDistance)
                    {
                        totalAmount -= curDistance;


                    }
                    else
                    {
                        reched = false;
                        startindex++;
                        queuePetrolPumps.Enqueue(queuePetrolPumps.Dequeue());
                        break;
                    }


                }
                if (reched == true)
                {
                    Console.WriteLine(startindex);
                    return;
                }
                
            }



        }
    }
}
