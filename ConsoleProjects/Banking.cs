using System;

// This class is used to make a simple banking program
public static class Banking
{
    // This method runs the whole banking system
    // The program starts from here
    public static void RunSimpleBankSystem()
    {
        const int correctPin = 7878; // This is the correct PIN number
        const int maxAttempts = 3;   // User can try the PIN only 3 times

        // Before doing anything, the user must enter the correct PIN
        if (!AuthenticateUser(correctPin, maxAttempts)) // If PIN is wrong
        {
            Console.ForegroundColor = ConsoleColor.Red; // Show error message in red color
            Console.WriteLine("Access denied. Too many invalid PIN attempts.");
            Console.ResetColor();
            return; // Stop the program
        }

        bool exitBank = false; // This is used to stop the program when user exits
        decimal balance = 0m;  // Account balance starts from zero

        // This loop keeps running until the user chooses Exit
        while (!exitBank)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n******************************");
            Console.WriteLine("     Simple Banking System     ");
            Console.WriteLine("******************************");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Balance Inquiry");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            Console.ResetColor();

            string? choice = Console.ReadLine(); // Take the user's choice

            // Switch is used to decide what the user wants to do
            switch (choice)
            {
                case "1":
                    balance = Deposit(balance); 
                    break;
                case "2":
                    balance = Withdraw(balance); 
                    break;
                case "3":
                    ShowBalance(balance); 
                    break;
                case "4":
                    exitBank = true; // The loop ends here
                    Console.WriteLine("Exiting Banking System. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select 1-4.");
                    break;
            }
        }
    }

    // This method checks whether the PIN entered is correct or not
    private static bool AuthenticateUser(int correctPin, int maxAttempts)
    {
        // Loop runs only for limited number of attempts
        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            Console.Write("Enter PIN: ");
            string? input = Console.ReadLine(); // Reads the PIN from user

            // Check if input is a number and matches the correct PIN
            if (int.TryParse(input, out int pin) && pin == correctPin)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login successful.");
                Console.ResetColor();
                return true; // This allows access
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Invalid PIN. Attempt {attempt} of {maxAttempts}.");
            Console.ResetColor();
        }

        return false; // Deny access after all attempts are used
    }

    // This method is used to add money to the account
    private static decimal Deposit(decimal balance)
    {
        Console.Write("Enter deposit amount: ");
        decimal amount = decimal.Parse(Console.ReadLine()); // Read deposit amount

        balance += amount; // Add amount to balance
        Console.WriteLine($"Deposited {amount:C}. New balance: {balance:C}");
        return balance;
    }

    // This method is used to take money from the account
    private static decimal Withdraw(decimal balance)
    {
        Console.Write("Enter withdrawal amount: ");
        decimal amount = decimal.Parse(Console.ReadLine()); // Read withdrawal amount

        // If user tries to withdraw more money than balance
        if (amount > balance)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Insufficient funds. Withdrawal denied.");
            Console.ResetColor();
            return balance;
        }

        balance -= amount; // Subtract amount from balance
        Console.WriteLine($"Withdrew {amount:C}. New balance: {balance:C}");
        return balance;
    }

    // This method shows how much money is in the account
    private static void ShowBalance(decimal balance)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Current balance: {balance:C}");
        Console.ResetColor();
    }
}