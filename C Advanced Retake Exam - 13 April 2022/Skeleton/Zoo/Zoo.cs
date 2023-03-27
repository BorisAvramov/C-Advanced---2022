using System;
using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {

        private List<Animal> animals;

        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            animals = new List<Animal>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => animals.Count;


        public string AddAnimal(Animal animal) 
        {

            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }

            if (Capacity  == animals.Count)
            {
                return "The zoo is full.";
            }
            animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";

        }

        public int RemoveAnimals(string species)
        {
            

            int count =  animals.RemoveAll(a => a.Species == species);

            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet) 
        {
            var filteredList = animals.Where(a => a.Diet == diet).ToList();

            return filteredList;
            
        }
        public Animal GetAnimalByWeight(double weight) 
        {
             Animal animalFirst = animals.FirstOrDefault(a => a.Weight == weight);
            return animalFirst;
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            int count = 0;
            foreach (var animal in animals)
            {
                if (animal.Length >= minimumLength && animal.Length <= maximumLength)
                {
                    count++;
                }


            }
            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }

    }
}
