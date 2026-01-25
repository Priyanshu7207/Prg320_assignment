using System;

namespace Week3.CustomException
{
    // This exception is used when wrong or invalid
    // data is entered for an item
    public class InvalidItemDataException : Exception
    {
        // Constructor to show a custom validation message
        public InvalidItemDataException(string message) : base(message)
        {
        }

        // Constructor to store the original error
        // along with the custom message
        public InvalidItemDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
