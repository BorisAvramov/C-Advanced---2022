using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string arExpr = Console.ReadLine();

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < arExpr.Length; i++)
            {
                if (arExpr[i] == '(')
                {
                    stack.Push(i);

                }
                if (arExpr[i] == ')')
                {
                    int startIndex = stack.Pop();

                    string subst = arExpr.Substring(startIndex, i - startIndex + 1);

                    Console.WriteLine(subst);



                    //for (int j = startIndex; j <= i; j++)
                    //{

                    //    Console.Write(arExpr[j]);

                    //}
                    //Console.WriteLine();
                }


            }


        }
    }
}
