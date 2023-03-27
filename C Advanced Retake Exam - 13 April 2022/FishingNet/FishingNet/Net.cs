using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private readonly List<Fish> fish;

        public Net(string material, int capacity)
        {
            Material = material;
            Capacity = capacity;
            fish = new List<Fish>();
        }

        public IReadOnlyCollection <Fish>  Fish => (IReadOnlyCollection<Fish>) this.fish;
        public string Material { get; set; }
        public int Capacity { get; set; }
        public int Count => this.fish.Count;


        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) ||
               fish.Lenght <= 0 ||
               fish.Weight <= 0)
            {
                return "Invalid fish.";
            }

            if (Count == Capacity)
            {
                return "Fishing net is full.";
            }
            this.fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";


            //if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Lenght <= 0 || fish.Weight <= 0)
            //{
            //    return "Invalid fish.";
            //}
            //if (Fish.Count + 1 > Capacity)
            //{
            //    return "Fishing net is full.";
            //}

            //this.fish.Add(fish);
            //return $"Successfully added {fish.FishType} to the fishing net.";


        }

        public bool ReleaseFish(double weight)
        {

            var fish = this.fish.FirstOrDefault(e => e.Weight == weight);
            if (fish != null)
            {
                return this.fish.Remove(fish);
            }
            return false;


            //var fish = this.Fish.FirstOrDefault(e => e.Weight == weight);
            //if (fish != null)
            //{
            //    return this.Fish.Remove(fish);
            //}
            //return false;


            //bool isThere = false;
            //foreach (Fish fish in Fish)
            //{
            //    if (fish.Weight == weight)
            //    {
            //        isThere = true;
            //        break;
            //    }
            //}

            //if (!isThere)
            //{
            //    return false;
            //}
            //else
            //{
            //    Fish removed = Fish.Where(f => f.Weight == weight).FirstOrDefault();

            //    Fish.Remove(removed);
            //    return true;

            //}
        }

        public Fish GetFish(string fishType)
        {
            var fish = this.fish.FirstOrDefault(e => e.FishType == fishType);
            return fish;



            //Fish fish = Fish.Where(f => f.FishType == fishType).FirstOrDefault();
            //return fish;
            ////return $"There is a {fishType}, {fish.Lenght} cm. long, and {fish.Weight} gr. in weight.";

        }
        public Fish GetBiggestFish()
        {


            var longestFish = this.fish.Max(e => e.Lenght);
            var fish = this.fish.FirstOrDefault(e => e.Lenght == longestFish);
            return fish;

            //double maxLenght = 0;
            //Fish maxFish = null;
            //foreach (var fish in Fish)
            //{
            //    if (fish.Lenght > maxLenght)
            //    {

            //        maxLenght = fish.Lenght;
            //        maxFish = fish;
            //    }
            //}

            //return maxFish;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Into the {Material}:");
            foreach (Fish fish in fish.OrderByDescending(x => x.Lenght))
            {
                sb.AppendLine(fish.ToString());

            }

            return sb.ToString().TrimEnd();
        }


    }
}
