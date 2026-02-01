using Week4Library.CustomExpectation;

namespace Week4Library.Model
{
    // This class represents a Magazine.
    // Magazine also inherits common data from LibraryItemBase.
    public class Magazine : LibraryItemBase
    {
        // Issue number of the magazine (example: Issue 5)
        public int IssueNumber { get; set; }

        // Constructor for Magazine
        public Magazine(string title, string publisher, int year, int issueNumber)
            : base(title, publisher, year)
        {
            // Check if issue number is valid
            if (issueNumber <= 0)
            {
                // Issue number must be positive
                throw new InvalidItemException(
                    "Issue number must be greater than zero."
                );
            }

            // Assign issue number
            IssueNumber = issueNumber;
        }

        // Display magazine information
        public override void DisplayInfo()
        {
            Console.WriteLine(
                $"[Magazine] Title: {Title}, Publisher: {Publisher}, Year: {PublicationYear}, Issue: {IssueNumber}"
            );
        }
    }
}
