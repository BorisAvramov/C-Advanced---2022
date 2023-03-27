using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = nums[0];
            int m = nums[1];
            HashSet<int> nHash = new HashSet<int>();
            HashSet<int> mHash = new HashSet<int>();
            FillSet(nHash, n);
            FillSet(mHash, m);
            CheckRepeat(nHash, mHash);
 
        }

        private static void CheckRepeat(HashSet<int> nHash, HashSet<int> mHash)
        {
            HashSet<int> repeatElements = new HashSet<int>();
            foreach (var num in nHash)
            {
                
                    if (mHash.Contains(num))
                    {
                        repeatElements.Add(num);
                    }
                
            }
            Console.WriteLine(string.Join(" ", repeatElements));
        }

        private static HashSet<int> FillSet(HashSet<int> set, int lenght)
        {
            
            for (int i = 0; i < lenght; i++)
            {
                int curNum = int.Parse(Console.ReadLine());
                set.Add(curNum);
            }
            return set;
        }
    }
}
