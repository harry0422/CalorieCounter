using CalorieCounter.Common.Domain.Adapters;
using System;

namespace CalorieCounter.Common.Adapters.NetCore
{
    public class GuidIdentifierGenerator : IIdentifierGenerator
    {
        public string GetIdentifier()
        {
            return Guid.NewGuid().ToString();
        }
    }
}