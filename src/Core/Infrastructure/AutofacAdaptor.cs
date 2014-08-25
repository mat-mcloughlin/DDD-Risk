namespace Core.Infrastructure
{
    using System;
    using System.Collections.Generic;

    using Autofac;

    using MemBus;

    public class AutofacAdaptor : IocAdapter
    {
        private readonly IComponentContext _componentContext;

        public AutofacAdaptor(IComponentContext componentContext)
        {
            this._componentContext = componentContext;
        }

        public IEnumerable<object> GetAllInstances(Type desiredType)
        {
            var type = typeof(IEnumerable<>).MakeGenericType(desiredType);
            return (IEnumerable<object>)this._componentContext.Resolve(type);
        }
    }
}