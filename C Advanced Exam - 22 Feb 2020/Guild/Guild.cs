using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>();

        }

        public int Count => roster.Count;

        public string Name { get; private set; }
        public int Capacity { get; private set; }
        //public List<Player> MyProperty
        //{
        //    get { return roster; }
        //   private set { roster = value; }
        //}
        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {

            return roster.Any(p => p.Name == name) ?
                roster.Remove(roster.FirstOrDefault(p => p.Name == name))
                : false;

        }

        public void PromotePlayer(string name)
        {
            if (roster.Any(p => p.Name == name))
            {
                Player player = roster.FirstOrDefault(p => p.Name == name);

                if (player.Rank == "Trial")
                {
                    player.Rank = "Member";
                }
               
            }

        }
        public Player[] KickPlayersByClass(string @class)
        {
            List<Player> kicked = new List<Player>();

            foreach (var player in roster)
            {
                if (player.Class == @class)
                {
                    kicked.Add(player);
                    
                }
            }

            roster.RemoveAll(p => p.Class == @class);

             Player[] kickedArr = kicked.ToArray();

            return kickedArr;

        }

        public void DemotePlayer(string name)
        {
            if (roster.Any(p => p.Name == name))
            {
                Player player = roster.FirstOrDefault(p => p.Name == name);

                if (player.Rank == "Member")
                {
                    player.Rank = "Trial";
                }

            }

        }

        public string Report()
        {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var item in roster)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString().TrimEnd();

        }


    }
}
