using CalorieCounter.Common.Domain.Model;
using System;

namespace CalorieCounter.Foods.Domain.Model
{
    public class Food : EntityBase<string>
    {

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}