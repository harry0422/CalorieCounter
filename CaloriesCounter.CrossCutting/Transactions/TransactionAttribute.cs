using System;

namespace CaloriesCounter.CrossCutting.Transactions
{
    [AttributeUsage(AttributeTargets.Method)]
    public class TransactionAttribute : Attribute
    {

    }
}