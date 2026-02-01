using System;

namespace Week4Library.CustomExpectation
{
    // This exception is used when user input is not valid.
    public class InvalidItemException : Exception
    {
        public InvalidItemException(string message) : base(message) { }
    }
}
