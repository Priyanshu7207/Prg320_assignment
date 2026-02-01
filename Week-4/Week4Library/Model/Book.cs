using Week4Library.CustomExpectation;

namespace Week4Library.Model
{
    // This class represents a Book in the library.
    // It inherits common properties (Title, Publisher, Year)
    // from the LibraryItemBase class.
    public class Book : LibraryItemBase
    {
        // Private field to store author name
        private string _author = "";

        // Public property for Author
        // It controls how author value is set and read
        public string Author
        {
            get => _author; // Returns author name
            set
            {
                // Check if author name is empty or too short
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 5)
                {
                    // Throw custom exception if author is invalid
                    throw new InvalidItemException(
                        "Author name must be at least 5 characters long."
                    );
                }

                // Remove extra spaces
                value = value.Trim();

                // Capitalize first letter of author name
                _author = char.ToUpper(value[0]) + value.Substring(1);
            }
        }

        // Constructor of Book class
        // It receives data from user and sends common data
        // to the base class using 'base'
        public Book(string title, string publisher, int year, string author)
            : base(title, publisher, year)
        {
            // Set Author using property validation
            Author = author;
        }

        // This method displays book information on console
        // It overrides the abstract method from base class
        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"[Book] Title: {Title}, Publisher: {Publisher}, Year: {PublicationYear}, Author: {Author}"
            );
        }
    }
}
