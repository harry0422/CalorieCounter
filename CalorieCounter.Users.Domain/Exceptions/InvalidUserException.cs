using CalorieCounter.Common.Domain.Exceptions;
using CalorieCounter.Common.Domain.Model;
using System.Collections.Generic;

namespace CalorieCounter.Users.Domain.Exceptions
{
    public class InvalidUserException : BrokenRulesException
    {
        public InvalidUserException(IEnumerable<BusinessRule> brokenRules) : base(brokenRules)
        {

        }
    }
}