using CaloriesCounter.Common.Domain.Model;
using System;
using System.Collections.Generic;

namespace CaloriesCounter.Common.Domain.Exceptions
{
    public abstract class BrokenRulesException : Exception
    {
        private const string ERROR_FORMAT = "{0}: {1}\n";

        private readonly string _brokenRulesMessage;

        public BrokenRulesException(IEnumerable<BusinessRule> brokenrules) : base()
        {
            foreach (var rule in brokenrules)
            {
                _brokenRulesMessage += string.Format(ERROR_FORMAT, rule.Property, rule.Rule);
            }
        }

        public override string Message => _brokenRulesMessage;
    }
}