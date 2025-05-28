
using System.Linq.Expressions;

namespace Uppgift2
{
    internal class MainMenu
    {
        public MainMenu()
        {

            //Startar menyn som loopar tills användaren väljer att avsluta programmet
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("***********************************************");
                Console.WriteLine("*                                             *");
                Console.WriteLine("*     Välkommen till vår Huvudmeny!           *");
                Console.WriteLine("*                                             *");
                Console.WriteLine("***********************************************");
                Console.WriteLine("*   1. Ungdom eller pensionär                 *");
                Console.WriteLine("*   2. Helt sällskap                          *");
                Console.WriteLine("*   3. Upprepa tio gånger                     *");
                Console.WriteLine("*   4. Det tredje valet                       *");
                Console.WriteLine("*   5. Avsluta                                *");
                Console.WriteLine("***********************************************");
                Console.Write("Välj ett alternativ (1–4): ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        GetPriceForPerson();
                        PauseMenu();
                        break;
                    case "2":
                        CalculateGroupPrice();
                        PauseMenu();
                        break;
                    case "3":
                        RepeatFun();
                        PauseMenu();
                        break;
                    case "4":
                        ThirdWordChoice();
                        PauseMenu();
                        break;                    
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again.");
                        break;
                }
            }
        }

        //tar en mening och och splittar den i ord och skriver ut det tredje ordet
        private void ThirdWordChoice()
        {
            Console.WriteLine("Ange en mening med minst 3 ord: ");
            string input = Console.ReadLine();
            string[] words = input.Split(' ');
            if (words.Length < 3)
            {
                Console.WriteLine("Fel: Du måste ange minst tre ord.");
                return;
            }
            string thirdWord = words[2]; // Index 2 är det tredje ordet (0-baserat index)
            Console.WriteLine($"Det tredje ordet i meningen är: {thirdWord}");

        }

        // Denna metod upprepar en text 10 gånger som användaren skriver in
        private void RepeatFun()
        {
            Console.WriteLine("Skriv in en text som ska upprepas 10 gånger: ");
            string input = Console.ReadLine();

            Console.WriteLine(); // Skapar en tom rad innan upprepningen

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(input);
            }
        }

        // Denna metod pausar programmet och väntar på att användaren ska trycka på en tangent för att återgå till menyn
        // utan denna så skulle programmet avslutas direkt efter att användaren valt ett alternativ
        private void PauseMenu()
        {
            Console.WriteLine("\nTryck på valfri tangent för att återgå till menyn...");
            Console.ReadKey();
        }

        // Denna metod beräknar priset för ett helt sällskap
        private void CalculateGroupPrice()
        {
            Console.Write("Ange antalet personer i sällskapet: ");
            string input = Console.ReadLine();
            int numberOfPeople = 0;
            int totalSum = 0;

            try
            {
                numberOfPeople = int.Parse(input);

                if (numberOfPeople <= 0)
                {
                    Console.WriteLine("Fel: Ange ett heltal större än 0.");
                    return;
                }
            }
            catch
            {
                Console.WriteLine("Fel: Du måste skriva ett heltal för antalet personer.");
            }
            // Beräknar priset för varje person i sällskapet
            for (int i = 1; i <= numberOfPeople; i++)
            {
                int price = GetPriceForPerson();
                totalSum += price;
            }
            Console.WriteLine($"Totalt pris för sällskapet: {totalSum} kr");

        }

        // Denna metod beräknar priset för en person baserat på ålder
        private int GetPriceForPerson()
        {
            Console.Write("Ange ålder: ");
            string input = Console.ReadLine();

            try
            {
                int age = int.Parse(input);

                if (age < 20)
                {
                    Console.WriteLine("Ungdomspris: 80kr");
                    return 80;
                }
                else if (age >= 65)
                {
                    Console.WriteLine("Pensionärspris: 90kr");
                    return 90;
                }
                else
                {
                    Console.WriteLine("Standardpris: 120kr");
                    return 120;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Fel: Du måste skriva ett heltal för åldern.");
                return GetPriceForPerson(); // Försök igen vid fel
            }
            catch (OverflowException)
            {
                Console.WriteLine("Fel: Det angivna talet är för stort eller för litet.");
                return GetPriceForPerson(); // Försök igen vid fel
            }
        }


    }
}