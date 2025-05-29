using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift3_Pokemon.PokemonType;

namespace Uppgift3_Pokemon.Pokemons
{
    internal class Squirtle : WaterPokemon
    {
        public Squirtle(string name, int level, List<Attack> attacks) : base(name, level, attacks)
        {
        }
    }
}
