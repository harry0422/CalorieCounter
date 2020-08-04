using CalorieCounter.Common.Domain.Model;

namespace CalorieCounter.Users.Domain.Model
{
    public class DailyActivity : EntityBase<int>, IAggregateRoot
    {
        public virtual string Description { get; set; }
        public virtual double Factor { get; set; }

        protected override void Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}