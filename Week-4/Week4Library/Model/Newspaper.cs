using Week4Library.CustomExpectation;

namespace Week4Library.Model
{
    // This class represents a Newspaper.
    // It also inherits common properties from LibraryItemBase.
    public class Newspaper : LibraryItemBase
    {
        // Private variable to store editor name
        private string _editor = "";

        // Public property for Editor
        public string Editor
        {
            get => _editor; // Return editor name
            set
            {
                // Validate editor name
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 5)
                {
                    // Throw error if editor name is invalid
                    throw new InvalidItemException(
                        "Editor name must be at least 5 characters long."
                    );
                }

                // Remove extra spaces
                value = value.Trim();

                // Capitalize first letter
                _editor = char.ToUpper(value[0]) + value.Substring(1);
            }
        }

        // Constructor for Newspaper
        public Newspaper(string title, string publisher, int year, string editor)
            : base(title, publisher, year)
        {
            // Set editor name
            Editor = editor;
        }

        // Display newspaper information
        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"[Newspaper] Title: {Title}, Publisher: {Publisher}, Year: {PublicationYear}, Editor: {Editor}"
            );
        }
    }
}
