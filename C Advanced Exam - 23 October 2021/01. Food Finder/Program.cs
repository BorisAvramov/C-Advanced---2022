using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));

            Stack<char> consanants = new Stack<char>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse));



            string pear = "pear";
            string flour = "flour";
            string pork = "pork";
            string olive = "olive";

            int countPear = 4;
            int countFlour =5;
            int countPork = 4;
            int countOlive = 5;

            
           


            List<string> wordsFound = new List<string>();

            while (consanants.Count > 0)
            {
                char curVowel = vowels.Peek();
                char curConsanant = consanants.Peek();

                if (pear.Contains(curVowel))
                {
                    pear =  pear.Replace(curVowel, ' ');
                    countPear--;
                }

                if (flour.Contains(curVowel))
                {
                   flour = flour.Replace(curVowel, ' ');
                    countFlour--;
                }
                if (pork.Contains(curVowel))
                {
                    pork  = pork.Replace(curVowel, ' ');
                    countPork--;
                }
                if (olive.Contains(curVowel))
                {

                    olive = olive.Replace(curVowel, ' ');
                    countOlive--;
                }

                if (pear.Contains(curConsanant))
                {
                    pear = pear.Replace(curConsanant, ' ');
                    countPear--;
                }

                if (flour.Contains(curConsanant))
                {
                    flour = flour.Replace(curConsanant, ' ');
                    countFlour--;
                }
                if (pork.Contains(curConsanant))
                {
                    pork = pork.Replace(curConsanant, ' ');
                    countPork--;
                }
                if (olive.Contains(curConsanant))
                {

                    olive = olive.Replace(curConsanant, ' ');
                    countOlive--;
                }

               

                vowels.Dequeue();
                vowels.Enqueue(curVowel);
                consanants.Pop();


            }

            if (countPear == 0)
            {
                wordsFound.Add("pear");
            }
            if (countFlour == 0)
            {
                wordsFound.Add("flour");
            }
            if (countPork == 0)
            {
                wordsFound.Add("pork");
            }
            if (countOlive == 0)
            {
                wordsFound.Add("olive");
            }


            Console.WriteLine($"Words found: {wordsFound.Count}");
            foreach (var word in wordsFound)
            {
                Console.WriteLine(word);


            }


        }
    }
}
