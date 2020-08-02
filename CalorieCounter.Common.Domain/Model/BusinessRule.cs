namespace CalorieCounter.Common.Domain.Model
{
    public class BusinessRule
    {
        public BusinessRule(string property, string rule)
        {
            Property = property;
            Rule = rule;
        }

        public string Property { get; set; }
        public string Rule { get; set; }
    }
}