using System;

namespace CaloriesCounter.Common.Domain.Exceptions
{
    public class InvalidValueObjectException : Exception
    {
        public InvalidValueObjectException(string message) : base(message)
        {

        }
    }
}