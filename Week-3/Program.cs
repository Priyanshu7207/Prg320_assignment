using System;
using Week3.CustomException;
using Week3.Model;
using Week3.Service;

namespace Week3

{
    /// Main program for the Library Management System.
    /// Uses menu-driven approach with proper exception handling.
    internal class Program
    {
        private static void Main()
        {
            var libraryService = new LibraryService();
            bool exit = false;

            // MENU LOOP: Runs until user chooses to exit
            while (!exit)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n--------------------------------");
                Console.WriteLine("   LIBRARY MANAGEMENT SYSTEM   ");
                Console.WriteLine("--------------------------------");
                Console.ResetColor();

                Console.WriteLine("1. Add a Book");
                Console.WriteLine("2. Add a Magazine");
                Console.WriteLine("3. View All Library Items");
                Console.WriteLine("4. Exit Program");
                Console.Write("Select your option: ");

                string choice = Console.ReadLine() ?? string.Empty;

                // TRY-CATCH-FINALLY: Handles all errors safely
                try
                {
                    switch (choice)
                    {
                        case "1":
                            var book = CreateBookFromInput();
                            libraryService.AddItem(book);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Book has been added successfully.");
                            Console.ResetColor();
                            break;

                        case "2":
                            var magazine = CreateMagazineFromInput();
                            libraryService.AddItem(magazine);
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Magazine has been added successfully.");
                            Console.ResetColor();
                            break;

                        case "3":
                            libraryService.DisplayAllItems();
                            break;

                        case "4":
                            exit = true;
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Program closed. Thank you!");
                            Console.ResetColor();
                            break;

                        default:
                            Console.WriteLine("Invalid selection. Please choose between 1 and 4.");
                            break;
                    }
                }
                catch (InvalidItemDataException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Validation Error: {ex.Message}");
                    Console.ResetColor();
                }
                catch (DuplicateEntryException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Duplicate Entry Error: {ex.Message}");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"System Error: {ex.Message}");
                    Console.ResetColor();
                }
                finally
                {
                    Console.WriteLine("Returning to menu...\n");
                }
            }
        }

        private static Book CreateBookFromInput()
        {
            Console.Write("Enter book name: ");
            string title = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter publisher name: ");
            string publisher = Console.ReadLine() ?? string.Empty;

            int year = ReadPublicationYear("Enter year of publication (YYYY): ");

            Console.Write("Enter author name: ");
            string author = Console.ReadLine() ?? string.Empty;

            return new Book(title, publisher, year, author);
        }

        private static Magazine CreateMagazineFromInput()
        {
            Console.Write("Enter magazine title: ");
            string title = Console.ReadLine() ?? string.Empty;

            Console.Write("Enter publisher name: ");
            string publisher = Console.ReadLine() ?? string.Empty;

            int year = ReadPublicationYear("Enter year of publication (YYYY): ");

            int issueNumber = ReadInt("Enter magazine issue number: ", mustBePositive: true);

            return new Magazine(title, publisher, year, issueNumber);
        }

        private static int ReadPublicationYear(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(input, out int year))
                {
                    if (year >= 1000 && year <= 9999)
                    {
                        return year;
                    }
                    Console.WriteLine("Please enter a valid 4-digit year.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Numbers only.");
                }
            }
        }

        private static int ReadInt(string prompt, bool mustBePositive = false)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine() ?? string.Empty;

                if (int.TryParse(input, out int value))
                {
                    if (!mustBePositive || value > 0)
                    {
                        return value;
                    }
                    Console.WriteLine("Number must be greater than zero.");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
    }
}
