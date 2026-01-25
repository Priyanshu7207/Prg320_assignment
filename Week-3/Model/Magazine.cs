using System;
using Week3.CustomException;

namespace Week3.Model
{
    // Magazine class represents magazines in the library
    // It inherits common properties from Item class
    public class Magazine : Item
    {
        // Stores the issue number of the magazine
        private int _issueNumber;

        // Property to get and set issue number
        public int IssueNumber
        {
            get { return _issueNumber; }
            set
            {
                if (value <= 0)
                    throw new InvalidItemDataException("Issue number must be greater than zero.");

                _issueNumber = value;
            }
        }

        // Constructor to initialize magazine details
        public Magazine(string title, string publisher, int publicationYear, int issueNumber)
            : base(title, publisher, publicationYear)
        {
            IssueNumber = issueNumber;
        }

        // Overrides DisplayItems method
        // Displays magazine specific information
        public override void DisplayItems()
        {
            Console.WriteLine("=== MAGAZINE DETAILS ===");
            base.DisplayItems();
            Console.WriteLine($"Issue Number: {_issueNumber}");
        }
    }
}
