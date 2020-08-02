using CaloriesCounter.Common.Domain.Model;
using System;

namespace CaloriesCounter.Users.Domain.Model
{
    public class User : EntityBase<string>, IAggregateRoot
    {
        public User(string email, string password, string name, string age)
        {
            Email = email;
            Password = password;
            Name = name;
            Age = age;
            CreationDate = DateTime.Now;
            Status = UserStatus.Active;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public DateTime CreationDate { get; set; }
        public UserStatus Status { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}