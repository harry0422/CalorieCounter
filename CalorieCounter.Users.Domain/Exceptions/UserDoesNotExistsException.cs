using System;

namespace CalorieCounter.Users.Domain.Exceptions
{
    public class UserDoesNotExistsException : Exception
    {
        public UserDoesNotExistsException() : base("User does not exist.")
        {

        }
    }
}