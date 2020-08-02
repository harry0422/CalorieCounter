using System;

namespace CalorieCounter.CrossCutting.Transactions
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TransactionAttribute : Attribute
    {

    }
}