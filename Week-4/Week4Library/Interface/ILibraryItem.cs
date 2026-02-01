namespace Week4Library.Interface
{
    // This interface sets rules for every library item.
    public interface ILibraryItem
    {
        string Title { get; set; }
        string Publisher { get; set; }
        int PublicationYear { get; set; }

        // Every item must know how to display itself.
        void DisplayInfo();
    }
}
