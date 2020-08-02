using CalorieCounter.Common.Domain.Model;
using CalorieCounter.Users.Domain.BusinessRules;
using System;

namespace CalorieCounter.Users.Domain.Model
{
    public class User : EntityBase<string>, IAggregateRoot
    {
        public User() { }
        public User(string id, string email, string password, string name, int age)
        {
            Id = id;
            Email = email;
            Password = password;
            Name = name;
            Age = age;
            CreationDate = DateTime.Now;
            Status = UserStatus.Active;
        }

        public virtual string Email { get; set; }
        public virtual string Password { get; set; }
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public virtual DateTime CreationDate { get; set; }
        public virtual UserStatus Status { get; set; }

        protected override void Validate()
        {
            if (string.IsNullOrEmpty(Email)) AddBrokenRule(UserBusinessRules.EmailIsRequired);
            if (string.IsNullOrEmpty(Password)) AddBrokenRule(UserBusinessRules.PasswordIsRequired);
            if (string.IsNullOrEmpty(Name)) AddBrokenRule(UserBusinessRules.NameIsRequired);
            if (Age == 0) AddBrokenRule(UserBusinessRules.AgeIsRequired);
        }
    }
}