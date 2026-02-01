using Week4Library.Interface;
using Week4Library.CustomExpectation;

namespace Week4Library.Model
{
    // This is the base class for Book, Magazine, and Newspaper.
    // It holds common properties like Title, Publisher, and Year.
    public abstract class LibraryItemBase : ILibraryItem
    {
        private string _title = "";
        private string _publisher = "";
        private int _year;

        public string Title
        {
            get => _title;
            set => _title = ValidateText(value, "Title");
        }

        public string Publisher
        {
            get => _publisher;
            set => _publisher = ValidateText(value, "Publisher");
        }

        public int PublicationYear
        {
            get => _year;
            set
            {
                if (value < 1000 || value > 9999)
                    throw new InvalidItemException("Publication year must be a 4-digit year (1000-9999).");
                _year = value;
            }
        }

        // This constructor sets the common values.
        protected LibraryItemBase(string title, string publisher, int year)
        {
            Title = title;
            Publisher = publisher;
            PublicationYear = year;
        }

        // This makes sure text is not empty and has at least 5 characters.
        // It also capitalizes the first letter.
        protected string ValidateText(string value, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidItemException($"{fieldName} cannot be empty.");

            value = value.Trim();

            if (value.Length < 5)
                throw new InvalidItemException($"{fieldName} must be at least 5 characters long.");

            // Capitalize first letter
            return char.ToUpper(value[0]) + value.Substring(1);
        }

        // Child classes must create their own DisplayInfo method.
        public abstract void DisplayInfo();
    }
}
