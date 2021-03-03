namespace BullsAndCows
{
    partial class Program
    {

        const int GAMEMODE_INDEX_MIN = 0;
        const int GAMEMODE_INDEX_MAX = 3;
        const int NUMBER_LENGTH_MIN = 1;
        const int NUMBER_LENGTH_MAX = 10;
        const int DIGIT_LOWER_BOUND = 0;
        const int DIGIT_UPPER_BOUND = 9;

        const string ERROR_MSG_INCORRECT_GAMEMODE_INPUT = "[!] Your input can only be a number: 1, 2, 3 (or 0 to exit)!";
        const string ERROR_MSG_INCORRECT_SYMBOLS_IN_GUESS = "[!] Your guess has to be a number!";
        const string ERROR_MSG_INCORRECT_LENGTH_OF_GUESS = "[!] Your guess doesn't match the required length!";
        const string ERROR_MSG_INCORRECT_NUMBER_LENGTH = "[!] You can only input a number between 1 and 10!";
        const string ERROR_MSG_REPEATING_DIGITS_IN_GUESS = "[!] You cannot have repeating digits in your guess!";
        const string ERROR_MSG_UNEXPECTED_ERROR = "[!] Something went wrong. Restarting the game will probably fix it...";
        const string ERROR_MSG_CANNOT_GIVE_UP_IN_TUTORIAL = "[!] You cannot give up right now!";

        const string REPEAT_CHOICE = "[>] Please, input your choice again: ";
        const string REPEAT_GUESS = "[>] Please, input your guess again: ";

        const string GIVE_UP_STRING = "GIVE UP";

    }
}