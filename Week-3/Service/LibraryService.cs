using System;
using System.Collections.Generic;
using Week3.Model;
using Week3.CustomException;

namespace Week3.Service
{
    // Service class that manages library operations
    public class LibraryService
    {
        // List to store all library items
        private List<Item> _items = new List<Item>();

        // Adds a new item to the library
        public void AddItem(Item item)
        {
            if (item == null)
                throw new InvalidItemDataException("Item cannot be null.");

            foreach (Item existingItem in _items)
            {
                if (existingItem.Title == item.Title &&
                    existingItem.Publisher == item.Publisher &&
                    existingItem.PublicationYear == item.PublicationYear)
                {
                    throw new DuplicateEntryException("This item already exists in the library.");
                }
            }

            _items.Add(item);
        }

        // Displays all items in the library
        public void DisplayAllItems()
        {
            if (_items.Count == 0)
            {
                Console.WriteLine("Library is empty.");
                return;
            }

            foreach (Item item in _items)
            {
                item.DisplayItems();
                Console.WriteLine();
            }
        }

        // Returns total number of items
        public int GetItemCount()
        {
            return _items.Count;
        }
    }
}
