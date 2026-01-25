using System;
using Week3.CustomException;

namespace Week3.Model
{
    // Abstract class that represents a common
    // structure for all library items
    public abstract class Item
    {
        // Stores the title of the item
        private string _title;

        // Stores the publisher name
        private string _publisher;

        // Stores the year of publication
        private int _publicationYear;

        // Property to get and set the title
        // Includes validation rules
        public string Title
        {
            get { return _title; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Title cannot be empty.");

                if (value.Length < 5)
                    throw new InvalidItemDataException("Title must have at least 5 characters.");

                if (!char.IsUpper(value[0]))
                    throw new InvalidItemDataException("Title must start with a capital letter.");

                _title = value;
            }
        }

        // Property to get and set publisher name
        public string Publisher
        {
            get { return _publisher; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new InvalidItemDataException("Publisher cannot be empty.");

                if (value.Length < 6)
                    throw new InvalidItemDataException("Publisher must have at least 6 characters.");

                if (!char.IsUpper(value[0]))
                    throw new InvalidItemDataException("Publisher must start with a capital letter.");

                _publisher = value;
            }
        }

        // Property to get and set publication year
        public int PublicationYear
        {
            get { return _publicationYear; }
            set
            {
                if (value < 1000 || value > 9999)
                    throw new InvalidItemDataException("Year must be a 4-digit number.");

                _publicationYear = value;
            }
        }

        // Constructor to initialize item details
        protected Item(string title, string publisher, int publicationYear)
        {
            Title = title;
            Publisher = publisher;
            PublicationYear = publicationYear;
        }

        // Virtual method to display item details
        // This method can be overridden by child classes
        public virtual void DisplayItems()
        {
            Console.WriteLine($"Title: {_title}");
            Console.WriteLine($"Publisher: {_publisher}");
            Console.WriteLine($"Publication Year: {_publicationYear}");
        }
    }
}
