using System; 
// This allows us to use built-in C# features like Console, colors, and input/output.

namespace Week4Library.Utilities
{
    // This static class stores helper methods.
    // These methods are used in many parts of the program to avoid repeating code.
    public static class Utilities
    {
        // This method prints the main menu on the screen.
        // It uses colors to make the menu look nice and easy to read.
        public static void PrintMenu()
        {
            // Clears the console screen before showing the menu.
            Console.Clear();

            // Changes the text color to dark blue.
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            // Prints the title of the program.
            Console.WriteLine("==================================");
            Console.WriteLine("      Library Management System   ");
            Console.WriteLine("==================================");

            // Resets the text color back to normal.
            Console.ResetColor();

            // Changes the text color to dark yellow for menu options.
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            // Displays all menu choices for the user.
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Add Magazine");
            Console.WriteLine("3. Add Newspaper");
            Console.WriteLine("4. Display All Items");
            Console.WriteLine("5. Remove Item");
            Console.WriteLine("6. Search by Title");
            Console.WriteLine("7. Search by Author");
            Console.WriteLine("8. Sort by Title");
            Console.WriteLine("9. Sort by Year");
            Console.WriteLine("10. Exit");

            // Resets the text color back to default.
            Console.ResetColor();

            // Prints an empty line for spacing.
            Console.WriteLine();
        }

        // This method prints a message in a specific color.
        // It is useful for showing errors, warnings, or important messages.
        public static void ColorWrite(string message, ConsoleColor color)
        {
            // Sets the text color to the chosen color.
            Console.ForegroundColor = color;

            // Writes the message without moving to a new line.
            Console.Write(message);

            // Resets the color so future text is normal.
            Console.ResetColor();
        }

        // This method pauses the program so the user can read the output.
        // The program waits until the user presses ENTER.
        public static void Pause()
        {
            // Sets the text color to yellow to grab attention.
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Tells the user how to continue.
            Console.WriteLine("\nPress ENTER to continue...");

            // Resets the color back to default.
            Console.ResetColor();

            // Waits for the user to press ENTER.
            Console.ReadLine();
        }

        // This method safely reads an integer from the user.
        // It keeps asking until the user enters a valid number.
        public static int ReadInt(string prompt, bool mustBePositive)
        {
            // This loop runs forever until a valid number is returned.
            while (true)
            {
                // Displays the prompt message in white color.
                ColorWrite(prompt, ConsoleColor.White);

                // Reads input from the user.
                string? input = Console.ReadLine();

                // Tries to convert the input into an integer.
                if (int.TryParse(input, out int value))
                {
                    // Checks if the number must be positive.
                    if (mustBePositive && value <= 0)
                    {
                        // Shows an error message if the number is not positive.
                        ColorWrite("Please enter a positive number.\n", ConsoleColor.Red);
                        continue; // Goes back to the start of the loop.
                    }

                    // Returns the valid number.
                    return value;
                }

                // Shows an error message if input is not a number.
                ColorWrite("Please enter a valid number.\n", ConsoleColor.Red);
            }
        }
    }
}
