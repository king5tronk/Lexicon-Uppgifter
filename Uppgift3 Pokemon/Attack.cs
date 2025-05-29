using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3_Pokemon
{
    public class Attack
    {
        public string Name { get; set; }
        ElementType ElementType { get; set; }
        int BasePower { get; set; }

        public Attack(string name, ElementType elementType, int basePower)
        {
            Name = name;
            ElementType = elementType;
            BasePower = basePower;
        }

        public string Use(int level)
        {
            int damage = BasePower + level;
            return $"{Name} deals {damage} damage!";
        }
    }
}
