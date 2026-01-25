using System;
using Week3.CustomException;

namespace Week3.Model
{
    // Book class represents books in the library
    // It inherits common properties from Item class
    public class Book : Item
    {
        // Stores the name of the author
        private string _author;

        // Property to get and set author name
        public string Author
        {
            get { return _author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Author cannot be empty.");

                if (value.Length < 3)
                    throw new InvalidItemDataException("Author name must have at least 3 characters.");

                if (!char.IsUpper(value[0]))
                    throw new InvalidItemDataException("Author must start with a capital letter.");

                _author = value;
            }
        }

        // Constructor to initialize book details
        public Book(string title, string publisher, int publicationYear, string author)
            : base(title, publisher, publicationYear)
        {
            Author = author;
        }

        // Overrides DisplayItems method
        // Displays book specific information
        public override void DisplayItems()
        {
            Console.WriteLine("=== BOOK DETAILS ===");
            base.DisplayItems();
            Console.WriteLine($"Author: {_author}");
        }
    }
}
