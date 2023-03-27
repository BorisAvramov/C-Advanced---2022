using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOperation = int.Parse(Console.ReadLine());

            Stack<string[]> stack = new Stack<string[]>();

            string text = "";
            string erasedText = "";

            for (int i = 1; i <= numOperation ; i++)
            {
                string[] data = Console.ReadLine().Split().ToArray();
                string command = data[0];
                if (command == "1")
                {
                    string strToAdd = data[1];
                    text += strToAdd;
                    stack.Push(data);
                }
                else if (command == "2")
                {
                    int countLastErease = int.Parse(data[1]);
                    erasedText = text.Substring(text.Length - countLastErease);
                    if (text.Length == countLastErease)
                    {
                        text = "";
                    }
                    else
                    {
                        text = text.Substring(0, text.Length - countLastErease);
                    }
                   

                    stack.Push(data);
                }
                else if (command == "3" && data.Length > 1)
                {
                    int index = int.Parse(data[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (command == "4" && stack.Any())
                {
                    foreach (var item in stack)
                    {
                        if (item[0] == "1")
                        {
                            string undoText = item[1];
                            int firstIndex = text.IndexOf(undoText);
                            if (text.Length == undoText.Length)
                            {
                                text = "";
                            }
                            else
                            {
                                text = text.Substring(0, text.Length - firstIndex);
                            }

                            stack.Pop();

                            break;
                        }
                        else if (item[0] == "2")
                        {
                            string toAdd = erasedText;

                            text += toAdd;

                            stack.Pop();
                            break;
                        }
                    }
                   


                }
               

            }   

            
        }
    }
}
