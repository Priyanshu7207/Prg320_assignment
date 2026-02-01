using System;
using Week4Library.Model;
using Week4Library.Service;
using Week4Library.CustomExpectation;
using Week4Library.Utilities;

namespace Week4Library
{
    class Program
    {
        static void Main()
        {
            // This object does all the main work (add, remove, search, save, load, etc.)
            LibraryService service = new LibraryService();

            // This keeps the app running until user chooses Exit
            bool exit = false;

            while (!exit)
            {
                Utilities.Utilities.PrintMenu();

                Utilities.Utilities.ColorWrite("Choose an option: ", ConsoleColor.White);
                string? choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            service.AddItem(CreateBook());
                            Utilities.Utilities.ColorWrite("Book added successfully.", ConsoleColor.Green);
                            break;

                        case "2":
                            service.AddItem(CreateMagazine());
                            Utilities.Utilities.ColorWrite("Magazine added successfully.", ConsoleColor.Green);
                            break;

                        case "3":
                            service.AddItem(CreateNewspaper());
                            Utilities.Utilities.ColorWrite("Newspaper added successfully.", ConsoleColor.Green);
                            break;

                        case "4":
                            service.DisplayAllItems();
                            break;

                        case "5":
                            Utilities.Utilities.ColorWrite("Enter title to remove: ", ConsoleColor.White);
                            service.RemoveItem(Console.ReadLine() ?? "");
                            break;

                        case "6":
                            Utilities.Utilities.ColorWrite("Enter title to search: ", ConsoleColor.White);
                            service.SearchByTitle(Console.ReadLine() ?? "");
                            break;

                        case "7":
                            Utilities.Utilities.ColorWrite("Enter author to search (Books only): ", ConsoleColor.White);
                            service.SearchByAuthor(Console.ReadLine() ?? "");
                            break;

                        case "8":
                            service.SortByTitle();
                            break;

                        case "9":
                            service.SortByYear();
                            break;

                        case "10":
                            exit = true;
                            Utilities.Utilities.ColorWrite("Goodbye! Program closed.", ConsoleColor.Green);
                            break;

                        default:
                            Utilities.Utilities.ColorWrite("Invalid option. Try again.", ConsoleColor.Red);
                            break;
                    }
                }
                catch (InvalidItemException ex)
                {
                    // This happens when user types bad input like short title, wrong year, etc.
                    Utilities.Utilities.ColorWrite("Input Error: " + ex.Message, ConsoleColor.Red);
                }
                catch (DuplicateItemException ex)
                {
                    // This happens when user adds the same item again
                    Utilities.Utilities.ColorWrite("Duplicate Error: " + ex.Message, ConsoleColor.Red);
                }
                catch (Exception ex)
                {
                    // Any unexpected error goes here
                    Utilities.Utilities.ColorWrite("Unexpected Error: " + ex.Message, ConsoleColor.Red);
                }

                Utilities.Utilities.Pause();
            }
        }

        // This method asks user for book info and creates a Book object
        static Book CreateBook()
        {
            Utilities.Utilities.ColorWrite("Enter Title: ", ConsoleColor.White);
            string title = Console.ReadLine() ?? "";

            Utilities.Utilities.ColorWrite("Enter Publisher: ", ConsoleColor.White);
            string publisher = Console.ReadLine() ?? "";

            int year = Utilities.Utilities.ReadInt("Enter Publication Year (YYYY): ", mustBePositive: true);

            Utilities.Utilities.ColorWrite("Enter Author: ", ConsoleColor.White);
            string author = Console.ReadLine() ?? "";

            return new Book(title, publisher, year, author);
        }

        // This method asks user for magazine info and creates a Magazine object
        static Magazine CreateMagazine()
        {
            Utilities.Utilities.ColorWrite("Enter Title: ", ConsoleColor.White);
            string title = Console.ReadLine() ?? "";

            Utilities.Utilities.ColorWrite("Enter Publisher: ", ConsoleColor.White);
            string publisher = Console.ReadLine() ?? "";

            int year = Utilities.Utilities.ReadInt("Enter Publication Year (YYYY): ", mustBePositive: true);
            int issue = Utilities.Utilities.ReadInt("Enter Issue Number: ", mustBePositive: true);

            return new Magazine(title, publisher, year, issue);
        }

        // This method asks user for newspaper info and creates a Newspaper object
        static Newspaper CreateNewspaper()
        {
            Utilities.Utilities.ColorWrite("Enter Title: ", ConsoleColor.White);
            string title = Console.ReadLine() ?? "";

            Utilities.Utilities.ColorWrite("Enter Publisher: ", ConsoleColor.White);
            string publisher = Console.ReadLine() ?? "";

            int year = Utilities.Utilities.ReadInt("Enter Publication Year (YYYY): ", mustBePositive: true);

            Utilities.Utilities.ColorWrite("Enter Editor: ", ConsoleColor.White);
            string editor = Console.ReadLine() ?? "";

            return new Newspaper(title, publisher, year, editor);
        }
    }
}
