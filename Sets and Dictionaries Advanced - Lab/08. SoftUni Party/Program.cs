using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _08._SoftUni_Party
{
    class Program
    {
        static void Main(string[] args)
        {
            string patternReg = @"^[^0-9]\w{7}$";
            string patternVip = @"^[0-9]\w{7}$";
            Regex regexReg = new Regex(patternReg);
            Regex regexVip = new Regex(patternVip);
            HashSet<string> vipList = new HashSet<string>();
            HashSet<string> regList = new HashSet<string>();
            string input = Console.ReadLine();
            while (input != "PARTY")
            {


                if (regexReg.IsMatch(input))
                {

                    regList.Add(input);

                }
                else if (regexVip.IsMatch(input))
                {
                    vipList.Add(input);
                }

                input = Console.ReadLine();

            }
            string input2 = Console.ReadLine();
            while (input2 != "END")
            {
                if (regexReg.IsMatch(input2))
                {

                    regList.Remove(input2);

                }
                else if (regexVip.IsMatch(input2))
                {
                    vipList.Remove(input2);
                }

                input2 = Console.ReadLine();
            }
            int count = regList.Count + vipList.Count;
            Console.WriteLine(count);
            if (vipList.Count > 0)
            {
                foreach (var vip in vipList)
                {
                    Console.WriteLine(vip);
                }
            }
            if (regList.Count > 0)
            {
                foreach (var reg in regList)
                {
                    Console.WriteLine(reg);
                }
            }
        }
    }
}
