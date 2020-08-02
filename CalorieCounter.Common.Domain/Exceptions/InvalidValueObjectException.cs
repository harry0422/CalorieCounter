using System;

namespace CalorieCounter.Common.Domain.Exceptions
{
    public class InvalidValueObjectException : Exception
    {
        public InvalidValueObjectException(string message) : base(message)
        {

        }
    }
}