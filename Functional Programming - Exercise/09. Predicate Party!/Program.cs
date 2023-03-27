using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split(" ").ToList();

            


            while (true)
            {
                string command = Console.ReadLine();

                if (command == "Party!")
                {
                    break;
                }

                string[] commandData = command.Split(" ");

                if (commandData[0] == "Remove")
                {
                    //Predicate<string> filterRemove = GetFilterRemove(guests, commandData);

                    //guests = guests.Where(g => !filterRemove(g)).ToList();

                    guests.RemoveAll(GetFilterRemoveAndDouble(guests, commandData));
                }
                else if (commandData[0] == "Double")
                {
                    List<string> doubleGuests =  guests.FindAll(GetFilterRemoveAndDouble(guests, commandData));
                    if (doubleGuests.Count > 0)
                    {
                        int index = guests.FindIndex(GetFilterRemoveAndDouble(guests, commandData));

                        guests.InsertRange(index, doubleGuests);
                    }
                    
                }
                



            }

            if (guests.Count > 0)
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }

        

        private static Predicate<string> GetFilterRemoveAndDouble(List<string> guests, string[] commandData)
        {
            switch (commandData[1])
            {
                case "StartsWith":
                    return guest => guest.StartsWith(commandData[2]);
                    //return guest => guest[0] == char.Parse(commandData[2]);
                case "EndsWith":
                    return guest => guest.EndsWith(commandData[2]);
                case "Length":
                    return guest => guest.Length == int.Parse(commandData[2]);

                default:
                    return null;
                        
                    
            }

        }
    }
}
