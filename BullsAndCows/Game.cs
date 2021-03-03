using System;

namespace BullsAndCows
{
    partial class Program
    {

        /// <summary>
        /// Launches the tutorial gamemode with a standard, 4-digit number.
        /// </summary>
        private static void PlayTutorial(int targetNumberLength = 4)
        {

            Console.Clear();
            Console.WriteLine(Environment.NewLine + "\t1 > TUTORIAL" + Environment.NewLine);

            int[] targetNumber;
            string targetNumberAsString;

            Console.WriteLine("Welcome to BULLS AND COWS!" + Environment.NewLine);
            Console.WriteLine($"It's a guessing game. The computer has just generated a {targetNumberLength}-digit number.");
            Console.WriteLine($"You have to guess what it is by naming your own {targetNumberLength}-digit numbers.");
            Console.WriteLine(Environment.NewLine + "Try naming one now, and remember the two main rules:");
            Console.WriteLine("\t> No digits occur more than once;" + Environment.NewLine + "\t> Zero cannot be the starting digit!");
            Console.Write(Environment.NewLine + "[>] Input your guess and hit ENTER: ");

            int numberOfBulls;
            int numberOfCows;
            int[] userGuess;
            string userInputString;
            bool hasGivenUp = false;

            // Disabling giving up for the first two guesses.
            (userGuess, userInputString) = GetUserGuessNoGivingUp(targetNumberLength, ref hasGivenUp);

            // Since it's a tutorial (!), we don't want the user to accidentally guess the number first try.
            // Therefore, IF the user (somehow) got the number first try, generating it again and
            // checking the bulls and cows for THAT NEW number.
            do
            {
                (targetNumber, targetNumberAsString) = GenerateNumber(targetNumberLength);
                (numberOfBulls, numberOfCows) = CheckForBullsAndCows(targetNumber, userGuess);
            } while (NumberGuessed(numberOfBulls, targetNumberLength));

            Console.WriteLine(Environment.NewLine + $"Well done! You had {numberOfBulls} bulls and {numberOfCows} cows in your guess!");
            Console.WriteLine(Environment.NewLine + $"That means that {numberOfBulls} digits are correct AND in the right place (they are called BULLS),");
            Console.WriteLine($"while the other {numberOfCows} are correct BUT NOT in the right place (they are called COWS).");
            Console.Write(Environment.NewLine + $"Try to input another {targetNumberLength}-digit number and see if it gets better: ");

            // Second guess cannot be a give up as well.
            (userGuess, userInputString) = GetUserGuessNoGivingUp(targetNumberLength, ref hasGivenUp);

            (numberOfBulls, numberOfCows) = CheckForBullsAndCows(targetNumber, userGuess);

            // If user HASN'T guessed the number correctly, from this point on, play the game like it would go in any other gamemode.
            if (!NumberGuessed(numberOfBulls, targetNumberLength))
            {
                Console.WriteLine(Environment.NewLine + $"{userInputString}:");
                Console.WriteLine($"{numberOfBulls} bulls / {numberOfCows} cows");

                Console.WriteLine(Environment.NewLine + "I think you get the idea! Now try to guess the number that the computer has generated.");
                Console.WriteLine("And remember: NO repeating digits, and NO leading zeroes!" + Environment.NewLine);

                // Initiates the normal game process.
                Guess(targetNumber, targetNumberAsString);
            }
            else
            {
                // If the user HAS guessed the number, stop the tutorial.
                Console.WriteLine(Environment.NewLine + $"[*] YOU HAVE GUESSED THE NUMBER!");
                Console.WriteLine($"[*] It was: {targetNumberAsString}. Well done! *claps*");
            }

        }


        /// <summary>
        /// Gets user's guess without an option of giving up.
        /// </summary>
        /// <param name="targetNumberLength">Number of digits in the target number.</param>
        /// <param name="hasGivenUp">Reference to a boolean for detecting whether the user
        /// decided to give up.</param>
        /// <returns>A tuple of values: first - an array of digits (user's guess);
        /// second - user's input as a string.</returns>
        private static (int[], string) GetUserGuessNoGivingUp(int targetNumberLength, ref bool hasGivenUp)
        {
            string userInputString = GetInputNoGivingUp(targetNumberLength, ref hasGivenUp);
            int[] userGuess = new int[targetNumberLength];

            for (int i = 0; i < userInputString.Length; i++)
            {
                userGuess[i] = GetNumberFromString(userInputString[i]);
            }
            return (userGuess, userInputString);
        }


        /// <summary>
        /// Gets user's input without an option of giving up.
        /// </summary>
        /// <param name="targetNumberLength">Number of digits in the generated number.</param>
        /// <param name="hasGivenUp">Reference to a boolean for detecting if user wants to give up.</param>
        /// <returns>Correct user input (user cannot give up).</returns>
        private static string GetInputNoGivingUp(int targetNumberLength, ref bool hasGivenUp)
        {

            string userInputString;
            do
            {
                if (hasGivenUp)
                {
                    Console.WriteLine(Environment.NewLine + ERROR_MSG_CANNOT_GIVE_UP_IN_TUTORIAL);
                    Console.Write(REPEAT_GUESS);
                }
                hasGivenUp = false;
                userInputString = GetUserInput(targetNumberLength, ref hasGivenUp);
            } while (hasGivenUp);
            return userInputString;

        }


        /// <summary>
        /// Launches a game of Bulls And Cows.
        /// </summary>
        /// <param name="targetNumberLength">Number of digits in the number to be guessed (default = 4).</param>
        private static void PlayBullsAndCows(int targetNumberLength = 4)
        {

            int[] targetNumber;
            string targetNumberString;

            // Generates a number "targetNumber" as an array, and a string representation of it "targetNumberString".
            (targetNumber, targetNumberString) = GenerateNumber(targetNumberLength);

            // Launches the guessing mechanic.
            Guess(targetNumber, targetNumberString);

        }


        /// <summary>
        /// Checks if the user wants to play the game again.
        /// </summary>
        /// <returns>true, if user wants to play again (by hitting the ENTER key); false, otherwise.</returns>
        private static bool AskForPlayAgain()
        {

            Console.WriteLine(Environment.NewLine + "[>] Do you want to play again?");
            Console.Write("[>] Press ENTER for YES, and ANY OTHER KEY for NO: ");

            var userKeyPressed = Console.ReadKey().Key;
            return (userKeyPressed == ConsoleKey.Enter);

        }

    }
}