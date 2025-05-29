namespace Uppgift3_Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var charmander = new Pokemons.Charmander("Charmander", 5, new List<Attack> { AttackLibrary.Flamethrower, AttackLibrary.Ember });
            var squirtle = new PokemonType.WaterPokemon("Squirtle", 5, new List<Attack> { AttackLibrary.Bubble, AttackLibrary.Surf });
            var pikachu = new PokemonType.ElectricPokemon("Pikachu", 5, new List<Attack> { AttackLibrary.Thunderbolt, AttackLibrary.Thunder });

            var pokemonList = new List<Pokemon> { charmander, squirtle, pikachu };

            foreach (var pokemon in pokemonList)
            {
                pokemon.RaiseLevel();
                Console.WriteLine(pokemon.Attack(pokemon.Attacks[0]));
                if (pokemon is IEvolvable evolvablePokemon)
                {
                    evolvablePokemon.Evolve();
                }
            }
        }
    }
}
