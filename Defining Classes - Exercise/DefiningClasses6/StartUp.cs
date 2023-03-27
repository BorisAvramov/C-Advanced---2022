using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses6
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();
            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Tournament")
                {
                    break;
                }
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = data[0];
                string pokemonName = data[1];
                string pokemonElement = data[2];
                int pokemonHealth = int.Parse(data[3]);

                Pokemon curPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                bool doubleName = false;
                foreach (var trainer in trainers)
                {
                    if (trainer.Name == trainerName)
                    {
                        doubleName = true;
                        trainer.Pokemons.Add(curPokemon);
                        break;
                    }
                }
                if (!doubleName)
                {
                    Trainer curTrainer = new Trainer(trainerName);
                    curTrainer.Pokemons.Add(curPokemon);
                    trainers.Add(curTrainer);
                }

            }

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

              
                    foreach (var trainer in trainers)
                    {
                        bool elementPresent = false;
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            if (pokemon.Element == input)
                            {
                                trainer.Badges++;
                                 elementPresent = true;
                                break;
                               
                            }
                        }
                        if (!elementPresent)
                        {
                        trainer.Pokemons.ForEach(pokemon => pokemon.Health -= 10);
                        trainer.Pokemons.RemoveAll(pokemon => pokemon.Health <= 0);
                        //foreach (var pokemon in trainer.Pokemons)
                        //{
                        //    pokemon.Health -= 10;

                        //    if (pokemon.Health <= 0)
                        //    {
                        //trainer.Pokemons.Remove(pokemon);
                        //        if (trainer.Pokemons.Count == 0)
                        //        {
                        //            break;
                        //        }
                        //    }
                        //}


                    }
                        
                    }


                
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }

        }
    }
}
