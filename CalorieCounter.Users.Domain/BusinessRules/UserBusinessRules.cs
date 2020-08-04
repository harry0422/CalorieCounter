using CalorieCounter.Common.Domain.Model;

namespace CalorieCounter.Users.Domain.BusinessRules
{
    public static class UserBusinessRules
    {
        public static BusinessRule EmailIsRequired
        {
            get { return new BusinessRule("Email", "Email is required."); }
        }

        public static BusinessRule PasswordIsRequired
        {
            get { return new BusinessRule("Password", "Password is required."); }
        }

        public static BusinessRule NameIsRequired
        {
            get { return new BusinessRule("Name", "Name is required."); }
        }

        public static BusinessRule AgeIsRequired
        {
            get { return new BusinessRule("Age", "Age is required."); }
        }

        public static BusinessRule WeightIsRequired
        {
            get { return new BusinessRule("Weight", "Weight is required."); }
        }

        public static BusinessRule HeightIsRequired
        {
            get { return new BusinessRule("Height", "Height is required."); }
        }

        public static BusinessRule GenderIsRequired
        {
            get { return new BusinessRule("Gender", "Gender is required."); }
        }

        public static BusinessRule DailyActivityIsRequired
        {
            get { return new BusinessRule("DailyActivity", "DailyActivity is required."); }
        }
    }
}