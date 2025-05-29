using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3_Pokemon.PokemonType
{
    internal class ElectricPokemon : Pokemon
    {
        public ElectricPokemon(string name, int level, List<Attack> attacks)
            : base(name, level, ElementType.Electric, attacks) // 🔥 ElementType sätts automatiskt här
        {
        }
    }
}
