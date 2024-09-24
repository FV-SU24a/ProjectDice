namespace ProjectDice
{
    class Program
    {
        static void Main()
        {
            //using this to help me see all the different parts of my code easier
            //remember future me /n makes the text go to a new line REMEMBER
            Random random = new Random();
            int userTotalSum = 0;
            int dealerTotalSum = 0;
            string userChoice;

            Console.WriteLine("Welcome to the gambling game! Try not to go over 21 points.");

            while (true)
            {
                // User's Turn
                Console.WriteLine("Type 'Roll' to roll the dice, 'Stay' to stay, or 'Stop' to end the game:");
                userChoice = Console.ReadLine().ToLower();

                if (userChoice == "stop")
                {
                    Console.WriteLine("Game ended.");
                    break; // Ends the game
                }

                if (userChoice == "roll")
                {
                    int userRoll = random.Next(1, 7);
                    userTotalSum += userRoll;
                    Console.WriteLine($"You rolled: {userRoll}");
                    Console.WriteLine($"Your total: {userTotalSum}");

                    // Checks if user goes over 21
                    if (userTotalSum > 21)
                    {
                        Console.WriteLine("You went over 21! You lose.");
                        break;
                    }
                }
                else if (userChoice == "stay")
                {
                    Console.WriteLine("You chose to stay.");
                    break;
                }
                else
                {
                    Console.WriteLine("Please type 'Roll', 'Stay', or 'Stop'.");
                }
            }

            // Dealers Turn
            if (userTotalSum <= 21)
            {
                Console.WriteLine("Dealer's turn.");

                while (dealerTotalSum < 18)
                {
                    int dealerRoll = random.Next(1, 7);
                    dealerTotalSum += dealerRoll;
                    Console.WriteLine($"Dealer rolled: {dealerRoll}");
                    Console.WriteLine($"Dealer's total: {dealerTotalSum}");

                    if (dealerTotalSum > 21)
                    {
                        Console.WriteLine("Dealer went over 21! You win.");
                        break;
                    }
                }

                if (dealerTotalSum <= 21)
                {
                    Console.WriteLine($"\nGame ended. Your total score: {userTotalSum}, Dealer's total score: {dealerTotalSum}");

                    if (userTotalSum > dealerTotalSum)
                    {
                        Console.WriteLine("Congratulations! You win.");
                    }
                    else if (userTotalSum < dealerTotalSum)
                    {
                        Console.WriteLine("Dealer wins.");
                    }
                    else
                    {
                        Console.WriteLine("It's a tie!");
                    }
                }
            }

            // Ask user if they want to play again
            Console.WriteLine("Do you want to play again? Type 'Yes' to start a new game or 'No' to end.");
            string playAgain = Console.ReadLine().ToLower();

            if (playAgain == "yes")
            {
                // Restart the game
                Main(); // Call Main method again to restart the game
            }
            else
            {
                Console.WriteLine("Thank you for playing!");
            }
        }
    }
}
