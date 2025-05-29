using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uppgift3_Pokemon.PokemonType;

namespace Uppgift3_Pokemon.Pokemons
{
    internal class Charmander : FirePokemon, IEvolvable
    {
        public Charmander(string name, int level, List<Attack> attacks) : base(name, level, attacks)
        {

        }

        public void Evolve()
        {
            Level += 10;
            Console.WriteLine("Charmander has evolved into Charmeleon!");
            Name = "Charmeleon";
        }
    }
}
