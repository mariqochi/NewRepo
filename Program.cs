using System;

class NumberGuessingGame
{
    static void Main(string[] args)
    {
        // Step 1: User selects the range
        int minRange, maxRange;

        Console.WriteLine("Welcome to the Number Guessing Game!");

        // Ask the user to enter the minimum and maximum values for the range
        Console.Write("Enter the minimum value for the range: ");
        while (!int.TryParse(Console.ReadLine(), out minRange))
        {
            Console.Write("Please enter a valid integer for the minimum value: ");
        }

        Console.Write("Enter the maximum value for the range: ");
        while (!int.TryParse(Console.ReadLine(), out maxRange) || maxRange <= minRange)
        {
            Console.Write("Please enter a valid integer greater than the minimum value for the maximum value: ");
        }

        // Generate a random number within the given range
        Random random = new Random();
        int secretNumber = random.Next(minRange, maxRange + 1);

        // Initialize attempts
        int attempts = 0;
        bool gameOver = false;

        Console.WriteLine($"A number has been generated between {minRange} and {maxRange}. Start guessing!");

        while (!gameOver)
        {
            Console.Clear();
            // Prompt the user to guess the number
            Console.Write("Enter your guess: ");
            int userGuess;

            // Validate user input
            if (!int.TryParse(Console.ReadLine(), out userGuess))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                continue; // Skip the rest of the loop and ask the user for input again
            }

            // Check if the user's guess is within the range
            if (userGuess < minRange || userGuess > maxRange)
            {
                Console.WriteLine($"You are out of range! Please guess a number between {minRange} and {maxRange}.");
                continue; // Skip this guess and don't count it as an attempt
            }

            // Increment the attempt counter
            attempts++;

            // Check if the guess is correct
            if (userGuess == secretNumber)
            {
                Console.WriteLine($"Congratulations! You guessed the number {secretNumber} in {attempts} attempts.");
                gameOver = true;
            }
            else
            {
                // Provide a hint to the user
                if (userGuess < secretNumber)
                {
                    Console.WriteLine("The number is higher.");
                }
                else
                {
                    Console.WriteLine("The number is lower.");
                }

                // Display the number of attempts so far
                Console.WriteLine($"Number of attempts: {attempts}");
            }

            // Ask if the user wants to continue the game
            if (!gameOver)
            {
                Console.Write("Do you want to continue? (y/n): ");
                string response = Console.ReadLine().ToLower();
                if (response != "y")
                {
                    Console.WriteLine("Thanks for playing!");
                    gameOver = true;
                }
            }
        }
    }
}
