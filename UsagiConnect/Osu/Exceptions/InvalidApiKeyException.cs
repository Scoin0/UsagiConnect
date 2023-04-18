using System;

namespace UsagiConnect.Osu.Exceptions
{
    public class InvalidApiKeyException : Exception
    {
        public InvalidApiKeyException() { }

        public InvalidApiKeyException(string message) : base(string.Format("Invalid API Key: {0}.", message)) { }
    }
}