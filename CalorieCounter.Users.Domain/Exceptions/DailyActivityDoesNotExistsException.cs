using System;

namespace CalorieCounter.Users.Domain.Exceptions
{
    public class DailyActivityDoesNotExistsException : Exception
    {
        public DailyActivityDoesNotExistsException() : base("Daily activity does not exists.")
        {

        }
    }
}