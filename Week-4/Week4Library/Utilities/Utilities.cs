using System; 
// This line allows us to use basic C# features.
// Examples: Console input/output, colors, and built-in data types.

namespace Week4Library.Utilities
{
    // A namespace is used to organize code.
    // It helps keep utility/helper code separate from the main program.

    // This is a static utility class.
    // Static means we do NOT need to create an object to use these methods.
    // These methods help the program run smoothly and look better.
    public static class Utilities
    {
        // This method displays the main menu of the Library Management System.
        // It clears the screen first and then prints menu options using colors.
        public static void PrintMenu()
        {
            // Clears everything currently shown on the console screen.
            // This makes the menu look clean every time it appears.
            Console.Clear();

            // Sets the text color to dark blue for the title.
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            // Prints decorative lines and the system title.
            Console.WriteLine("==================================");
            Console.WriteLine("      Library Management System   ");
            Console.WriteLine("==================================");

            // Resets the color back to default so other text is not blue.
            Console.ResetColor();

            // Changes the text color to dark yellow for menu options.
            // This makes the options easy to see.
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            // Displays all choices the user can select from.
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

            // Resets the text color so future output is normal.
            Console.ResetColor();

            // Adds a blank line to separate menu from user input.
            Console.WriteLine();
        }

        // This method writes text in a specific color.
        // It is mainly used for prompts, warnings, and error messages.
        public static void ColorWrite(string message, ConsoleColor color)
        {
            // Changes the console text color to the provided color.
            Console.ForegroundColor = color;

            // Writes the message without moving to the next line.
            Console.Write(message);

            // Resets the color so it does not affect other text.
            Console.ResetColor();
        }

        // This method pauses the program.
        // It allows the user time to read messages before continuing.
        public static void Pause()
        {
            // Changes text color to yellow to grab attention.
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Displays a message asking the user to press ENTER.
            Console.WriteLine("\nPress ENTER to continue...");

            // Resets text color to default.
            Console.ResetColor();

            // Waits until the user presses ENTER.
            Console.ReadLine();
        }

        // This method safely reads an integer value from the user.
        // It prevents crashes caused by invalid input.
        public static int ReadInt(string prompt, bool mustBePositive)
        {
            // Infinite loop that keeps running until valid input is received.
            while (true)
            {
                // Displays the prompt message in white color.
                ColorWrite(prompt, ConsoleColor.White);

                // Reads user input from the keyboard.
                string? input = Console.ReadLine();

                // Tries to convert the input string into an integer.
                // If conversion fails, TryParse returns false.
                if (int.TryParse(input, out int value))
                {
                    // Checks if the number must be positive.
                    if (mustBePositive && value <= 0)
                    {
                        // Displays an error message in red if number is not positive.
                        ColorWrite("Please enter a positive number.\n", ConsoleColor.Red);

                        // Goes back to the start of the loop.
                        continue;
                    }

                    // If input is valid, return the number.
                    return value;
                }

                // If input is not a number, show an error message.
                ColorWrite("Please enter a valid number.\n", ConsoleColor.Red);
            }
        }
    }
}
