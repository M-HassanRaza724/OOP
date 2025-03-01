using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicDuel
{
    public class Stats
    {
        public string Name;
        public float Damage;
        public string Description;
        public float Penetration;
        public float Cost;
        public float Heal;

        public Stats(string name, float damage, float penetration, float heal, float cost, string description)
        {
            Name = name;
            Damage = damage;
            Penetration = penetration;
            Heal = heal;
            Cost = cost;
            Description = description;
        }
    }
}
