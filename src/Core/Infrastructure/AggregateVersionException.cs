namespace Core.Infrastructure
{
    using System;

    public class AggregateVersionException : Exception
    {
        public AggregateVersionException(Guid id, Type type, int version, int i)
        {
            throw new NotImplementedException();
        }
    }
}