using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift3_Pokemon
{
    public abstract class Pokemon
    {
        public string Name;

        private int level;
        public int Level
        {
            get => level;
            set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Level must be at least 1.");
                }
                level = value;
            }
        }

        //Read only property for ElementType
        public ElementType ElementType { get; private set; }

        public List<Attack> Attacks;

        protected Pokemon(string name, int level, ElementType elementType, List<Attack> attacks)
        {
            Name = name;
            Level = level;
            ElementType = elementType;
            Attacks = attacks;
        }

        public virtual string Attack(Attack attack)
        {
            Console.WriteLine($"{Name} attacks: ");
            for (int i = 0; i < Attacks.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Attacks[i].Name}");
            }
            Console.Write("Select an attack: ");
            string input = Console.ReadLine() ?? "1";
            int choice = int.TryParse(input, out choice) ? choice - 1 : 0;
            if (choice < 0 || choice >= Attacks.Count)
            {
                Console.WriteLine("Invalid choice, using default attack.");
                choice = 0;
            }
            var selectedAttack = Attacks[choice];
            return selectedAttack.Use(Level);

        }


        public virtual int RaiseLevel()
        {
            Level++;
            return Level;
        }

    }


}
