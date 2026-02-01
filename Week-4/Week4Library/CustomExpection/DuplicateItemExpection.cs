using System;

namespace Week4Library.CustomExpectation
{
    // This exception is used when an item already exists in the library.
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException(string message) : base(message) { }
    }
}
