using System;

namespace CalorieCounter.Users.Domain.Model
{
    public class UserBuilder
    {
        private User User { get; set; }

        public UserBuilder()
        {
            User = new User();
            User.Status = Status.Active;
            User.CreationDate = DateTime.Now;
        }
        
        public UserBuilder SetGeneralInformation(string id, string name)
        {
            User.Id = id;
            User.Name = name;

            return this;
        }

        public UserBuilder SetCredentials(string email, string password)
        {
            User.Email = email;
            User.Password = password;

            return this;
        }

        public UserBuilder SetBodyMeasures(int age, double weight, double height, Gender gender, DailyActivity dailyActivity)
        {
            User.Age = age;
            User.Weight = weight;
            User.Height = height;
            User.Gender = gender;
            User.DailyActivity = dailyActivity;

            return this;
        }

        public User GetInstance()
        {
            return User;
        }
    }
}