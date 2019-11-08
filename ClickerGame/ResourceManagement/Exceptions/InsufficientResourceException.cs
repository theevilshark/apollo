using System;

namespace ResourceManagement.Exceptions
{
    public class InsufficientResourceException : Exception
    {
        public InsufficientResourceException() : base() { }

        public InsufficientResourceException(string message) : base(message) { }

        public InsufficientResourceException(string message, Exception exception) : base(message, exception) { }
    }
}
