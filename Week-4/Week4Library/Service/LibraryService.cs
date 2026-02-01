using Week4Library.Interface;
using Week4Library.Model;
using Week4Library.CustomExpectation;

namespace Week4Library.Service
{
    // This class handles the main library operations.
    public class LibraryService
    {
        private List<ILibraryItem> _items = new();
        private const string FileName = "libraryFile.json";

        // Constructor loads existing data from file.
        public LibraryService()
        {
            LoadData();
        }

        // Adds a new item to the list and saves it.
        public void AddItem(ILibraryItem item)
        {
            if (CheckForDuplicates(item))
                throw new DuplicateItemException("This item already exists (same type + same details).");

            _items.Add(item);
            SaveData();
        }

        // Shows all items in the library.
        public void DisplayAllItems()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("No items in the library yet.");
                return;
            }

            Console.WriteLine($"Total items: {_items.Count}");
            for (int i = 0; i < _items.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _items[i].DisplayInfo();
            }
        }

        // Removes an item by title (case-insensitive).
        public void RemoveItem(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                Console.WriteLine("Title cannot be empty.");
                return;
            }

            var item = _items.FirstOrDefault(x =>
                x.Title.Equals(title.Trim(), StringComparison.OrdinalIgnoreCase));

            if (item == null)
            {
                Console.WriteLine("Item not found.");
                return;
            }

            _items.Remove(item);
            SaveData();
            Console.WriteLine("Item removed successfully.");
        }

        // Search items by title (partial match).
        public void SearchByTitle(string title)
        {
            var results = _items
                .Where(x => x.Title.Contains(title ?? "", StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("No items found with that title.");
                return;
            }

            Console.WriteLine($"Found {results.Count} item(s):");
            foreach (var item in results)
                item.DisplayInfo();
        }

        // Search books by author only.
        public void SearchByAuthor(string author)
        {
            var results = _items
                .OfType<Book>()
                .Where(b => b.Author.Contains(author ?? "", StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("No books found with that author.");
                return;
            }

            Console.WriteLine($"Found {results.Count} book(s):");
            foreach (var book in results)
                book.DisplayInfo();
        }

        // Sort items by title.
        public void SortByTitle()
        {
            _items = _items.OrderBy(x => x.Title).ToList();
            Console.WriteLine("Items sorted by title.");
        }

        // Sort items by year.
        public void SortByYear()
        {
            _items = _items.OrderBy(x => x.PublicationYear).ToList();
            Console.WriteLine("Items sorted by year.");
        }

        // Checks duplicates using 3-step logic:
        // 1) Same type
        // 2) Same title, publisher, year
        // 3) Same specific field (author/editor/issue)
        private bool CheckForDuplicates(ILibraryItem newItem)
        {
            foreach (var existing in _items)
            {
                if (existing.GetType() != newItem.GetType())
                    continue;

                bool sharedMatch =
                    existing.Title.Equals(newItem.Title, StringComparison.OrdinalIgnoreCase) &&
                    existing.Publisher.Equals(newItem.Publisher, StringComparison.OrdinalIgnoreCase) &&
                    existing.PublicationYear == newItem.PublicationYear;

                if (!sharedMatch)
                    continue;

                // Type-specific match
                if (existing is Book b1 && newItem is Book b2)
                    return b1.Author.Equals(b2.Author, StringComparison.OrdinalIgnoreCase);

                if (existing is Magazine m1 && newItem is Magazine m2)
                    return m1.IssueNumber == m2.IssueNumber;

                if (existing is Newspaper n1 && newItem is Newspaper n2)
                    return n1.Editor.Equals(n2.Editor, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }

        // Saves items into file in pipe format.
        private void SaveData()
        {
            try
            {
                using StreamWriter writer = new StreamWriter(FileName);

                foreach (var item in _items)
                {
                    writer.WriteLine(SerializeItem(item));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving data: " + ex.Message);
            }
        }

        // Loads items from file when program starts.
        private void LoadData()
        {
            try
            {
                if (!File.Exists(FileName))
                    return;

                _items.Clear();

                foreach (string line in File.ReadAllLines(FileName))
                {
                    var item = DeserializeItem(line);
                    if (item != null)
                        _items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading data: " + ex.Message);
            }
        }

        // Converts object to a string line.
        private string SerializeItem(ILibraryItem item)
        {
            if (item is Book b)
                return $"BOOK|{b.Title}|{b.Publisher}|{b.PublicationYear}|{b.Author}";

            if (item is Magazine m)
                return $"MAGAZINE|{m.Title}|{m.Publisher}|{m.PublicationYear}|{m.IssueNumber}";

            if (item is Newspaper n)
                return $"NEWSPAPER|{n.Title}|{n.Publisher}|{n.PublicationYear}|{n.Editor}";

            return "";
        }

        // Converts a string line back to an object.
        private ILibraryItem? DeserializeItem(string line)
        {
            var parts = line.Split('|');
            if (parts.Length < 5) return null;

            string type = parts[0];
            string title = parts[1];
            string publisher = parts[2];
            int year = int.Parse(parts[3]);
            string last = parts[4];

            return type switch
            {
                "BOOK" => new Book(title, publisher, year, last),
                "MAGAZINE" => new Magazine(title, publisher, year, int.Parse(last)),
                "NEWSPAPER" => new Newspaper(title, publisher, year, last),
                _ => null
            };
        }
    }
}
