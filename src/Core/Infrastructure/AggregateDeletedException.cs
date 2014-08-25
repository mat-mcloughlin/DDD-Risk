namespace Core.Infrastructure
{
    using System;

    public class AggregateDeletedException : Exception
    {
        public AggregateDeletedException(Guid id, Type type)
        {
            throw new NotImplementedException();
        }
    }
}