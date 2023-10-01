using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Linq.Expressions;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace GuessTheNumber
{
    internal class Program //Gustav Lind .Net23
    {
        static void Main(string[] args)
        {

            bool playAgain = true;


            while (playAgain)
            {

                Console.WriteLine("Hej och välkommen! jag tänker på ett nummer mellan 1 - 20. Kan du gissa vilket? Du får fem försök!");
                Random random = new Random();
                int number = random.Next(1, 21); // last number is exclusive and therfore put 21 so the number 20 is inclusive

                CheckGuess(number);  // Call the CheckGuess function to start the guessing game

                if (playAgain) //Ask player if wanna go again or exit
                {

                    Console.WriteLine("Vill du testa igen? Y/N");
                    String playerInput = Console.ReadLine().ToLower();
                    if (playerInput == "y")
                    {
                        playAgain = true;
                        Console.Clear();

                    }
                    else if (playerInput == "n")
                    {
                        playAgain = false;
                    }

                }
            } 

        }
        static bool CheckGuess(int number)
        {
            int guesses = 0; // Variable to keep track of the number of guesses
            bool play = false; //Variable to control the game loop


            while (!play)
            {

                try
                {

                    Console.WriteLine("Vänligen skriv en siffra");
                    int answer = Convert.ToInt32(Console.ReadLine());
                    guesses++; //We count the amount of guesses the player does

                    if (answer < number) // Check if the user's guess is too low, too high, or correct

                    {
                        Console.WriteLine("Du gissade för lågt, försök igen!");
                    }
                    else if (answer > number)
                    {
                        Console.WriteLine("Du gissade för högt, försök igen!");
                    }
                    else
                    {
                        Console.WriteLine("Grattis du gissade rätt! Det tog " + guesses + " Försök");
                        play = true; //exit the gameloop

                    }

                    if (guesses == 5) //If the player does 5tries, player fails.
                    {
                        Console.WriteLine("Du har bara en chans kvar!");

                    }
                    else if (guesses == 6) //exit the gameloop if player reach 6trys
                    {
                        play = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Fel, vänligen mata enbart in siffor!");
                }

            }
            return play; // Return play


        }

    }

}
