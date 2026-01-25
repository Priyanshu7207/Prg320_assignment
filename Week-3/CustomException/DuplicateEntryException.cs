using System;

namespace Week3.CustomException
{
    // This exception is used when the same item
    // is added more than one time in the library
    public class DuplicateEntryException : Exception
    {
        // This constructor sends a custom error message
        public DuplicateEntryException(string message) : base(message)
        {
        }

        // This constructor sends both the error message
        // and the original exception details
        public DuplicateEntryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
