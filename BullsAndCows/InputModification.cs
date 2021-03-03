using System;

namespace BullsAndCows
{
    partial class Program
    {

        /// <summary>
        /// Gets the user's guess.
        /// </summary>
        /// <param name="targetNumberLength">The number of digits in the generated number to be guessed.</param>
        /// <param name="hasGivenUp">Reference to a boolean that stores if the user wants to give up.</param>
        /// <returns>User's guess as a string.</returns>
        private static string GetUserInput(int targetNumberLength, ref bool hasGivenUp)
        {

            string userInput;

            bool exceptionOnGuessInputSymbols = false;
            bool exceptionOnGuessInputLength = false;
            bool exceptionOnRepeatingDigits = false;

            // Asking the user to input their guess until their input is correct.
            do
            {
                if (exceptionOnGuessInputLength)
                {
                    Console.WriteLine(Environment.NewLine + ERROR_MSG_INCORRECT_LENGTH_OF_GUESS);
                    Console.Write(REPEAT_GUESS);
                }
                else
                {
                    if (exceptionOnGuessInputSymbols)
                    {
                        Console.WriteLine(Environment.NewLine + ERROR_MSG_INCORRECT_SYMBOLS_IN_GUESS);
                        Console.Write(REPEAT_GUESS);
                    }
                    else
                    {
                        if (exceptionOnRepeatingDigits)
                        {
                            Console.WriteLine(Environment.NewLine + ERROR_MSG_REPEATING_DIGITS_IN_GUESS);
                            Console.Write(REPEAT_GUESS);
                        }
                    }
                }

                userInput = Console.ReadLine();

                if (userInput == GIVE_UP_STRING)
                {
                    hasGivenUp = true;
                    break;
                }

                // A tuple of booleans get values by checking the input (tuple = кортеж, see C# Documentation).
                (exceptionOnGuessInputLength, exceptionOnGuessInputSymbols, exceptionOnRepeatingDigits) =
                    CheckValidity(userInput, targetNumberLength);

            } while (exceptionOnGuessInputLength || exceptionOnGuessInputSymbols || exceptionOnRepeatingDigits);

            return userInput;

        }


        /// <summary>
        /// Checks if the input is valid in terms of length and the characters used.
        /// </summary>
        /// <param name="userInput">Input string.</param>
        /// <param name="targetNumberLength">Number of digits in the number to be guessed.</param>
        /// <returns>A tuple of booleans:
        /// first - true, if input length does NOT match the number of digits; false, otherwise;
        /// second - true, if an incorrect symbol has been found; false, otherwise;
        /// third - true, if input contains repeating digits; false, otherwise.</returns>
        private static (bool, bool, bool) CheckValidity(string userInput, int targetNumberLength)
        {

            bool exceptionFoundInLength = !(userInput.Length == targetNumberLength);
            bool exceptionFoundInSymbols = false;
            bool exceptionOnRepeatingDigits = false;

            string acceptedSymbols = "0123456789";
            bool characterFound;

            // Going through all characters in the user input.
            for (int i = 0; (i < userInput.Length) && (!exceptionFoundInSymbols); i++)
            {
                characterFound = false;

                // Checking if the i-th element of the array matches any of the characters
                // in the "acceptedSymbols" string.
                for (int j = 0; j < acceptedSymbols.Length; j++)
                {
                    if (userInput[i] == acceptedSymbols[j])
                    {
                        characterFound = true;
                        break;
                    }
                }

                // If no match was found, return an exception.
                if (!characterFound)
                {
                    exceptionFoundInSymbols = true;
                }
            }

            // Checking for repeating digits.
            for (int i = 0; (i < userInput.Length) && (!exceptionOnRepeatingDigits); i++)
            {
                for (int j = i + 1; (j < userInput.Length) && (!exceptionOnRepeatingDigits); j++)
                {
                    if (userInput[i] == userInput[j])
                    {
                        exceptionOnRepeatingDigits = true;
                    }
                }
            }

            return (exceptionFoundInLength, exceptionFoundInSymbols, exceptionOnRepeatingDigits);

        }


        /// <summary>
        /// Converts a character into an integer (representing a single digit), if possible.
        /// </summary>
        /// <param name="currentDigit">Character to be converted.</param>
        /// <returns>The integer representation of a character ('0' returns 0, '1' returns 1, etc.) if possible;
        /// int.MinValue otherwise.</returns>
        private static int GetNumberFromString(char currentDigit)
        {

            switch (currentDigit)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                // Should never happen since the program checks if the user has input wrong characters.
                default:
                    return int.MinValue;
            }

        }

    }
}