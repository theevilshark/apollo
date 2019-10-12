using System;

namespace ResourceManagement.Exceptions
{
    public class UpgradeException : Exception
    {
        public UpgradeException() : base() { }

        public UpgradeException(string message) : base(message) { }

        public UpgradeException(string message, Exception exception) : base(message, exception) { }
    }
}
