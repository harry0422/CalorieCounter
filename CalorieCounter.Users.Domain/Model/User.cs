using CalorieCounter.Common.Domain.Model;
using CalorieCounter.Users.Domain.BusinessRules;
using System;

namespace CalorieCounter.Users.Domain.Model
{
    public class User : EntityBase<string>, IAggregateRoot
    {
        public User() { }
        
        public static UserBuilder FromBuilder()
        {
            return new UserBuilder();
        }

        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public virtual double Weight { get; set; }
        public virtual double Height { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual DailyActivity DailyActivity { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual Status Status { get; set; }

        public virtual int DailyCaloriesNeeded
        {
            get { return Convert.ToInt32(BMR * DailyActivity.Factor); }
        }

        public virtual double BMR
        {
            get { return (Gender == Gender.Male) ? CalulateBMRForMen() : CalulateBMRForWomen(); }
        }

        private double CalulateBMRForMen()
        {
            return 66 + (13.7 * Weight) + (5 * Height) - (6.75 * Age);
        }

        private double CalulateBMRForWomen()
        {
            return 655 + (9.6 * Weight) + (1.8 * Height) - (4.7 * Age);
        }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Email)) AddBrokenRule(UserBusinessRules.EmailIsRequired);
            if (string.IsNullOrEmpty(Password)) AddBrokenRule(UserBusinessRules.PasswordIsRequired);
            if (string.IsNullOrEmpty(Name)) AddBrokenRule(UserBusinessRules.NameIsRequired);
            if (Age == 0) AddBrokenRule(UserBusinessRules.AgeIsRequired);
            if (Weight == 0) AddBrokenRule(UserBusinessRules.WeightIsRequired);
            if (Height == 0) AddBrokenRule(UserBusinessRules.HeightIsRequired);
            if (Gender == Gender.Undefined) AddBrokenRule(UserBusinessRules.GenderIsRequired);
            if (DailyActivity == null) AddBrokenRule(UserBusinessRules.DailyActivityIsRequired);
        }
    }
}