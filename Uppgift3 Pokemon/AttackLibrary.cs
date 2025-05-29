using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3_Pokemon
{
    public static class AttackLibrary
    {
        public static Attack Flamethrower = new Attack("Flamethrower", ElementType.Fire, 12);
        public static Attack Ember = new Attack("Ember", ElementType.Fire, 6);
        public static Attack Bubble = new Attack("Bubble", ElementType.Water, 7);
        public static Attack Surf = new Attack("Surf", ElementType.Water, 14);
        public static Attack Thunderbolt = new Attack("Thunderbolt", ElementType.Electric, 10);
        public static Attack Thunder = new Attack("Thunder", ElementType.Electric, 15);
    }
}
