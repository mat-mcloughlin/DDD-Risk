namespace Core.Infrastructure
{
    using System;

    public class AggregateNotFoundException : Exception
    {
        public AggregateNotFoundException(Guid id, Type type)
        {

        }
    }
}