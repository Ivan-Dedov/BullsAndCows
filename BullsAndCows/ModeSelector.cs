using System;

namespace BullsAndCows
{
    partial class Program
    {

        /// <summary>
        /// Allows the user to choose one of the possible three gamemodes in Bulls And Cows:
        /// tutorial, classic game (with 4-digit numbers),
        /// or custom game (with custom length numbers).
        /// </summary>
        /// <returns>1, if user selected Tutorial;
        /// 2, if user selected Classic Game;
        /// 3, if user selected Custom Game.</returns>
        private static int SelectMode()
        {

            bool exceptionOnGamemodeInput;

            Console.WriteLine(Environment.NewLine + ">>> Welcome to BULLS AND COWS! <<<");
            Console.WriteLine(Environment.NewLine + "[i] Please select a gamemode:");
            Console.WriteLine("\t1 > Tutorial");
            Console.WriteLine("\t2 > Classic Game");
            Console.WriteLine("\t3 > Custom Game");
            Console.WriteLine("\t0 > Exit the Game");
            Console.Write(Environment.NewLine + "[>] Input your choice (1, 2, 3, or 0) and hit ENTER: ");

            int gamemode;

            // Asking the user to input a gamemode until the input is correct.
            do
            {
                exceptionOnGamemodeInput = false;

                if (!int.TryParse(Console.ReadLine(), out gamemode))
                {
                    exceptionOnGamemodeInput = true;
                }
                else
                {
                    // If parsed, checking the gamemode so that it is 1, 2 or 3.
                    if ((gamemode < GAMEMODE_INDEX_MIN) || (gamemode > GAMEMODE_INDEX_MAX))
                    {
                        exceptionOnGamemodeInput = true;
                    }
                }

                // If user has input incorrect data.
                if (exceptionOnGamemodeInput)
                {
                    Console.WriteLine(Environment.NewLine + ERROR_MSG_INCORRECT_GAMEMODE_INPUT);
                    Console.Write(REPEAT_CHOICE);
                }

            } while (exceptionOnGamemodeInput);

            return gamemode;

        }


        /// <summary>
        /// Plays the chosen gamemode of Bulls And Cows.
        /// </summary>
        /// <param name="gamemode">Gamemode ID (1 - tutorial; 2 - classic 4-digit game;
        /// 3 - custom number of digits).</param>
        /// <param name="playAgain">Reference to a boolean variable for detecting
        /// whether the user wants to play again.</param>
        private static void PlayGamemode(int gamemode, ref bool playAgain)
        {

            switch (gamemode)
            {
                // User exits the game.
                case 0:
                    playAgain = false;
                    return;
                // Tutorial.
                case 1:
                    PlayTutorial();
                    break;

                // Classic 4-digit game.
                case 2:
                    Console.Clear();
                    Console.WriteLine(Environment.NewLine + "\t2 > CLASSIC GAME" + Environment.NewLine);

                    PlayBullsAndCows();
                    break;

                // Custom game.
                case 3:
                    Console.Clear();
                    Console.WriteLine(Environment.NewLine + "\t3 > CUSTOM GAME" + Environment.NewLine);
                    Console.Write("[>] Please input the length of the number to be guessed (between 1 and 10): ");
                    // Asking the user to input the length of the number to be generated.
                    int targetNumberLength = GetLength();

                    Console.Clear();
                    Console.WriteLine(Environment.NewLine + "\t3 > CUSTOM GAME" + Environment.NewLine);

                    PlayBullsAndCows(targetNumberLength);
                    break;

                // If an unexpected error occurred (which shouldn't happen).
                default:
                    Console.WriteLine(ERROR_MSG_UNEXPECTED_ERROR);
                    break;
            }

            // After the game has finished, switch..case is over, program moves on to this line.
            // Asking the user whether they want to play again.
            playAgain = AskForPlayAgain();

        }


        /// <summary>
        /// Asks the user to input the length of the number to be guessed, also handles related exceptions.
        /// </summary>
        /// <returns>The number of digits in the number to be generated.</returns>
        private static int GetLength()
        {

            int targetNumberLength;
            bool exceptionOnNumberLength;

            // Do-while loop runs until user inputs the correct number of digits to be generated.
            do
            {
                exceptionOnNumberLength = false;

                if (!int.TryParse(Console.ReadLine(), out targetNumberLength))
                {
                    exceptionOnNumberLength = true;
                }
                else
                {
                    // If parsed, checking the number (can only be within range [1..10]).
                    if ((targetNumberLength < NUMBER_LENGTH_MIN) || (targetNumberLength > NUMBER_LENGTH_MAX))
                    {
                        exceptionOnNumberLength = true;
                    }
                }

                if (exceptionOnNumberLength)
                {
                    Console.WriteLine(Environment.NewLine + ERROR_MSG_INCORRECT_NUMBER_LENGTH);
                    Console.Write(REPEAT_CHOICE);
                }

            } while (exceptionOnNumberLength);

            return targetNumberLength;

        }

    }
}

