using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver__not_included_in_final_score_
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceBulletr = int.Parse(Console.ReadLine());
            int burrelSize = int.Parse(Console.ReadLine());
            Stack<int> stackBullets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Queue<int> queueSafeLockSize = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int valueIntelig = int.Parse(Console.ReadLine());

            int countBullInBurrezl = 0;
            int countBulletShooted = 0;

            while (stackBullets.Any() && queueSafeLockSize.Any())
            {
                int currBullet = stackBullets.Peek();
                int currLock = queueSafeLockSize.Peek();
                if (currBullet <= currLock)
                {
                    queueSafeLockSize.Dequeue();
                    stackBullets.Pop();
                    countBulletShooted++;
                    Console.WriteLine("Bang!");
                }
                else
                {
                    stackBullets.Pop();
                    countBulletShooted++;
                    Console.WriteLine("Ping!");
                }
                countBullInBurrezl++;
                if (countBullInBurrezl == burrelSize && stackBullets.Any())
                {
                    Console.WriteLine("Reloading!");
                    countBullInBurrezl = 0;
                }
            }
            if (!queueSafeLockSize.Any())
            {
                int bulletCost = priceBulletr * countBulletShooted;
                int totalEarned = valueIntelig - bulletCost;

                Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${totalEarned}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queueSafeLockSize.Count}");
            }


        }
    }
}
