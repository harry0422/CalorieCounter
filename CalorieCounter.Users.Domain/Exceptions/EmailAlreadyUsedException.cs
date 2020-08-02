using System;

namespace CalorieCounter.Users.Domain.Exceptions
{
    public class EmailAlreadyUsedException : Exception
    {
        public EmailAlreadyUsedException() : base("Email is already used.")
        {

        }
    }
}