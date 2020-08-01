using CaloriesCounter.Common.Domain.Exceptions;
using System.Collections.Generic;
using System.Text;

namespace CaloriesCounter.Common.Domain.Model
{
    public abstract class ValueObjectBase
    {
        private readonly List<BusinessRule> _brokenRules = new List<BusinessRule>();

        protected abstract void Validate();

        public void ThrowExceptionIfInvalid()
        {
            _brokenRules.Clear();
            Validate();

            if (_brokenRules.Count > 0)
            {
                StringBuilder issues = new StringBuilder();
                foreach (BusinessRule businessRule in _brokenRules)
                    issues.AppendLine(businessRule.Rule);

                throw new InvalidValueObjectException(issues.ToString());
            }
        }

        protected void AddBrokenRule(BusinessRule businessRule)
        {
            _brokenRules.Add(businessRule);
        }
    }
}