namespace Core.Facts
{
    using System.Linq;

    using CommonDomain;
    using CommonDomain.Core;

    public static class AggregateBaseExtensions
    {
        public static T LastEvent<T>(this AggregateBase aggregateBase)
        {
            var aggregate = (IAggregate)aggregateBase;
            return (T)aggregate.GetUncommittedEvents().Cast<object>().ToList().Last();
        }
    }
}
