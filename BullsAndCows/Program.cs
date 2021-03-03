using System;

namespace BullsAndCows
{
    partial class Program
    {
        static void Main(string[] args)
        {

            bool playAgain = false;

            // Do-while loop runs until user wants to exit.
            do
            {
                Console.Clear();

                int gamemode = SelectMode();
                PlayGamemode(gamemode, ref playAgain);

            } while (playAgain);

            Console.Clear();
            for (int i = 0; i < 4; i++)
            {
                Console.Write(Environment.NewLine);
            }
            Console.Write("\t** Thank you for playing! **");
            for (int i = 0; i < 4; i++)
            {
                Console.Write(Environment.NewLine);
            }
            Console.WriteLine("[>] Press any key to exit...");
            Console.ReadKey();

        }

    }
}