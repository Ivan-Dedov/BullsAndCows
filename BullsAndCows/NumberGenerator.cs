using System;

namespace BullsAndCows
{
    partial class Program
    {

        /// <summary>
        /// Generates a pseudo-random positive integer.
        /// </summary>
        /// <param name="targetNumberLength">Length of the generated number array.</param>
        /// <returns>A tuple: an array containing digits of the generated number;
        /// and a string representation of the number.</returns>
        private static (int[], string) GenerateNumber(int targetNumberLength)
        {

            // Elemets of the array are digits of the number.
            int[] generatedNumber = new int[targetNumberLength];

            string generatedNumberAsString = "";

            for (int i = 0; i < targetNumberLength; i++)
            {
                int newDigit;

                // Do-while loop generates a new number until it doesn't match any of the digits already generated.
                do
                {
                    Random digitGenerator = new Random();

                    // Any digits EXCEPT THE FIRST can be any of these: {0, 1, 2, ..., 9}.
                    if (i != 0)
                    {
                        newDigit = digitGenerator.Next(DIGIT_LOWER_BOUND, DIGIT_UPPER_BOUND + 1);
                    }
                    // The first digit (i == 0) CANNOT be a zero, so preventing it from generating here.
                    else
                    {
                        newDigit = digitGenerator.Next(DIGIT_LOWER_BOUND + 1, DIGIT_UPPER_BOUND + 1);
                    }
                } while (DigitAlreadyOccurred(newDigit, i, generatedNumber));

                generatedNumber[i] = newDigit;
            }

            // Concatinating the elements of the array to form a string.
            for (int i = 0; i < targetNumberLength; i++)
            {
                generatedNumberAsString += generatedNumber[i];
            }

            return (generatedNumber, generatedNumberAsString);

        }


        /// <summary>
        /// Checks if a certain digit has already occurred in the previously generated array since repetitions are not allowed.
        /// </summary>
        /// <param name="newDigit">Value of the newly generated digit.</param>
        /// <param name="currentDigit">The index of the newly generated digit in the given array.</param>
        /// <param name="targetNumber">An array that stores all the digits of the number.</param>
        /// <returns>true, if a repetition has been detected; false, otherwise.</returns>
        private static bool DigitAlreadyOccurred(int newDigit, int currentDigit, int[] targetNumber)
        {

            bool repeatDetected = false;
            for (int i = 0; (i < currentDigit) && (!repeatDetected); i++)
            {
                if (newDigit == targetNumber[i])
                {
                    repeatDetected = true;
                }
            }
            return repeatDetected;

        }

    }
}