using System;

namespace Week4Library.Utilities
{
    public static class Utilities
    {
        // Prints the menu with nice colors.
        public static void PrintMenu()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("==================================");
            Console.WriteLine("      Library Management System   ");
            Console.WriteLine("==================================");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
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
            Console.ResetColor();

            Console.WriteLine();
        }

        // Writes text in a chosen color.
        public static void ColorWrite(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        // Pauses the screen so user can read output.
        public static void Pause()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nPress ENTER to continue...");
            Console.ResetColor();
            Console.ReadLine();
        }

        // Reads an integer safely from user.
        public static int ReadInt(string prompt, bool mustBePositive)
        {
            while (true)
            {
                ColorWrite(prompt, ConsoleColor.White);
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int value))
                {
                    if (mustBePositive && value <= 0)
                    {
                        ColorWrite("Please enter a positive number.\n", ConsoleColor.Red);
                        continue;
                    }
                    return value;
                }

                ColorWrite("Please enter a valid number.\n", ConsoleColor.Red);
            }
        }
    }
}
