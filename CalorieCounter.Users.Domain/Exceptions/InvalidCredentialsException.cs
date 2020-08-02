using System;

namespace CalorieCounter.Users.Domain.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException() : base("Invalid credentials.")
        {

        }
    }
}