
using System.Collections;
using System.Collections.Generic;

namespace Uppgift4_Minneshantering
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Fråga 1: Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess grundläggande funktion
            // Stacken
            // Snabbt minne där värdetyper (value types) lagras.
            // Variabler på stacken har en livstid kopplad till sitt anrop (t.ex. i en metod).
            // Allokeras och frigörs automatiskt.
            //
            // Heapen
            // Används för referenstyper (reference types), som objekt.
            // Mer flexibel men långsammare.
            // Hanteras av garbage collectorn (GC), som städar oanvänt minne.

            //EXEMPEL
            //    class Person
            //{
            //    public string Name;
            //}

            //class Program
            //{
            //    static void Main()
            //    {
            //        int age = 30; // Ligger på stacken (value type)

            //        Person p = new Person(); // p är en referens på stacken
            //        p.Name = "Alice";        // Själva objektet (Person) ligger på heapen
            //    }
            //}

            // Fråga 2. Vad är Value Types respektive Reference Types och vad skiljer dem åt?
            // Reference Types
            // Reference Types är typer som ärver från System.Object (eller är System.Object).
            // Exempel:
            // • class
            // • interface
            // • object
            // • delegate
            // • string

            // 🔹 Value Types
            // Value Types är typer som ärver från System.ValueType.
            // Exempel:
            // • bool
            // • byte
            // • char
            // • decimal
            // • double
            // • enum
            // • float
            // • int
            // • long
            // • sbyte
            // • short
            // • struct
            // • uint
            // • ulong
            // • ushort

            //Fråga 3
            // MyInt är en referenstyp (reference type).
            // När y = x sker, kopieras referensen, inte själva objektet.
            // Både x och y pekar nu på samma objekt i heapen.
            // Att ändra y.MyValue = 4 påverkar också x.MyValue, eftersom det är samma objekt.

            /// <summary>
            /// The main method, vill handle the menues for the program
            /// </summary>
            /// <param name="args"></param>

            // ÖVNING 1: ExamineList()
            // 2. När ökar listans kapactitet?
            // Listans kapacitet ökar när antalet element överstiger den nuvarande kapaciteten. När det inte längre finns plats i den underliggande arrayen, skapas en ny större array, och alla befintliga element kopieras dit.
            // 3. Med hur mycket ökar kapaciteten?
            // Kapaciteten fördubblas vanligtvis varje gång den ökas: Börjar ofta med kapacitet 4 eller 0, Sedan 4 → 8 → 16 → 32 → osv.
            // 4. Varför ökar inte kapaciteten i samma takt som element läggs till?
            // Att öka kapaciteten varje gång ett element läggs till skulle vara väldigt ineffektivt:
            // Varje ökning kräver minnesallokering + kopiering av gamla värden. Därför ökar kapaciteten exponentiellt, för att minimera antalet omallokeringar. Det är en prestandaoptimering.
            // 5. Minskar kapaciteten när element tas bort?
            // Nej, kapaciteten minskar inte automatiskt när element tas bort. Listan behåller den tidigare tilldelade arrayen för att vara förberedd för framtida tillägg.
            // Om du vill minska kapaciteten kan du anropa: "list.TrimExcess();"
            // 6. När är det fördelaktigt att använda en egendefinierad array istället för en lista?
            // Du vet i förväg hur många element du behöver. Du vill ha maximal prestanda (t.ex. i realtidssystem eller spel). Du inte behöver dynamisk storlek eller funktionaliteten i List<T>.
            // EX: "int[] fixedArray = new int[100]; // Allokerar exakt 100 platser direkt"

            // ÖVNING 3: ExamineStack()
            // Det är inte rättvist, eftersom den som kom sist blir expedierad först. Därför är stackar olämpliga för kö-situationer där först in borde betyda först ut(FIFO).

            // ÖVNING 4: CheckParenthesis()
            // Vi använder en stack, eftersom den följer FILO-principen: När vi öppnar en parentes (, {, [ så lägger vi den på stacken, När vi stöter på en stängande parentes ), }, ] så måste den matcha den senaste öppnade, alltså den som ligger överst på stacken
            // Logik på papper: Push:(, Push:{, Pop:}, Pop:) → Om alla matchar korrekt är uttrycket giltigt.


            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 5, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n5. ReverseText"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                        ReverseText();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5)");
                        break;
                }
            }
        }



        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {

                // Skapar en lista som lagrar strängar
                List<string> theList = new List<string>();

                // Sparar tidigare kapacitet för att kunna upptäcka när den förändras
                int previousCapacity = theList.Capacity;

                Console.WriteLine("Skriv in +namn för att lägga till eller -namn för att ta bort. Tryck Enter utan text för att avsluta.\n");

                // Loopar tills användaren lämnar input tomt (då avslutas metoden)
                while (true)
                {
                    Console.Write("Input: ");
                    string input = Console.ReadLine();

                    // Om användaren bara trycker Enter – avsluta loopen
                    if (string.IsNullOrEmpty(input))
                        break;

                    // Första tecknet styr vad som ska göras (+ eller -)
                    char nav = input[0];

                    // Resten av texten efter första tecknet är själva värdet
                    string value = input.Length > 1 ? input.Substring(1) : "";

                    // Använder switch-sats för att avgöra vad användaren vill göra
                    switch (nav)
                    {
                        case '+':
                            // Lägg till värdet i listan
                            theList.Add(value);
                            Console.WriteLine($"'{value}' lades till.");
                            break;

                        case '-':
                            // Försök ta bort värdet. Visa om det lyckades eller inte.
                            if (theList.Remove(value))
                                Console.WriteLine($"'{value}' togs bort.");
                            else
                                Console.WriteLine($"'{value}' fanns inte i listan.");
                            break;

                        default:
                            // Användaren skrev varken + eller -, visar felmeddelande
                            Console.WriteLine("Du måste börja med + eller -");
                            break;
                    }

                    // Skriv ut antal element i listan
                    Console.WriteLine($"Antal element: {theList.Count}");

                    // Skriv ut aktuell kapacitet (storleken på underliggande array)
                    Console.WriteLine($"Kapacitet: {theList.Capacity}");

                    // Om kapaciteten förändrats, visa info om det
                    if (theList.Capacity != previousCapacity)
                    {
                        Console.WriteLine($"Kapaciteten ökade från {previousCapacity} till {theList.Capacity}");
                        previousCapacity = theList.Capacity;
                    }

                    Console.WriteLine(); // Lägg till en tom rad för bättre läsbarhet
                }

                Console.WriteLine("Tillbaka till huvudmenyn.");
            }


        

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
                // Skapar en ny kö med strängar
                Queue<string> queue = new Queue<string>();

                Console.WriteLine("Skriv in +namn för att ställa någon i kön, eller - för att expediera första personen i kön.");
                Console.WriteLine("Tryck Enter utan text för att avsluta.\n");

                while (true)
                {
                    Console.Write("Input: ");
                    string input = Console.ReadLine();

                    // Avslutar loopen om användaren trycker bara Enter
                    if (string.IsNullOrEmpty(input))
                        break;

                    // Om användaren vill lägga till någon i kön
                    if (input.StartsWith("+"))
                    {
                        string person = input.Substring(1);
                        queue.Enqueue(person);
                        Console.WriteLine($" {person} ställde sig i kön.");
                    }
                    // Om användaren vill ta bort (expediera) första i kön
                    else if (input.StartsWith("-"))
                    {
                        if (queue.Count > 0)
                        {
                            string removed = queue.Dequeue();
                            Console.WriteLine($" {removed} blev expedierad och lämnade kön.");
                        }
                        else
                        {
                            Console.WriteLine("Kön är tom. Ingen att expediera.");
                        }
                    }
                    else
                    {
                        Console.WriteLine(" Ogiltigt kommando. Använd +namn för att lägga till eller - för att ta bort.");
                    }

                    // Visa nuvarande kön
                    Console.WriteLine(" Aktuell kö: " + string.Join(", ", queue));
                    Console.WriteLine();
                }

                Console.WriteLine("Tillbaka till huvudmenyn.");
            }


        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
                Stack<string> stack = new Stack<string>();

                Console.WriteLine("Skriv in +namn för att lägga till på stacken (push), eller - för att ta bort översta (pop).");
                Console.WriteLine("Tryck Enter utan text för att avsluta.\n");

                while (true)
                {
                    Console.Write("Input: ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                        break;

                    if (input.StartsWith("+"))
                    {
                        string value = input.Substring(1);
                        stack.Push(value);
                        Console.WriteLine($" {value} lades på stacken.");
                    }
                    else if (input.StartsWith("-"))
                    {
                        if (stack.Count > 0)
                        {
                            string popped = stack.Pop();
                            Console.WriteLine($" {popped} togs bort från stacken.");
                        }
                        else
                        {
                            Console.WriteLine("Stacken är tom. Inget att ta bort.");
                        }
                    }
                    else
                    {
                        Console.WriteLine(" Ogiltigt kommando. Använd +värde för att lägga till eller - för att ta bort.");
                    }

                    Console.WriteLine(" Nuvarande stack: " + string.Join(", ", stack));
                    Console.WriteLine();
                }

                Console.WriteLine("Tillbaka till huvudmenyn.");
            }


        static void CheckParanthesis()
        {
            Console.Write("Skriv in en sträng att kontrollera: ");
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            bool isValid = true;

            foreach (char c in input)
            {
                // Om det är en öppnande parentes, lägg på stacken
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);
                }
                // Om det är en stängande parentes, kontrollera matchning
                else if (c == ')' || c == '}' || c == ']')
                {
                    // Om stacken är tom – det finns inget att matcha med
                    if (stack.Count == 0)
                    {
                        isValid = false;
                        break;
                    }

                    char last = stack.Pop();

                    // Kontrollera om rätt typ av parentes stängs
                    if ((c == ')' && last != '(') ||
                        (c == '}' && last != '{') ||
                        (c == ']' && last != '['))
                    {
                        isValid = false;
                        break;
                    }
                }
                // Andra tecken ignoreras
            }

            // Efter genomgång – stacken måste vara tom för att det ska vara korrekt
            if (isValid && stack.Count == 0)
                Console.WriteLine(" Strängen är välformad!");
            else
                Console.WriteLine(" Strängen är INTE välformad.");

            Console.WriteLine(); // Lägg till en tom rad för bättre läsbarhet

        }
        private static void ReverseText()
        {
            Console.Write("Skriv en sträng du vill vända: ");
            string input = Console.ReadLine();

            Stack<char> charStack = new Stack<char>();

            // Lägg varje tecken i stacken
            foreach (char c in input)
            {
                charStack.Push(c);
            }

            // Plocka ut i omvänd ordning
            string reversed = "";

            while (charStack.Count > 0)
            {
                reversed += charStack.Pop();
            }

            Console.WriteLine($"Omvänd sträng: {reversed}\n");

        }

    }

}

