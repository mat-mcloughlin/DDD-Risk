namespace Core.Infrastructure
{
    using Autofac;

    public class AutofacCommandHandlerResolver : ICommandHandlerResolver
    {
        private readonly ILifetimeScope _lifetimeScope;

        public AutofacCommandHandlerResolver(ILifetimeScope lifetimeScope)
        {
            _lifetimeScope = lifetimeScope;
        }

        public ICommandHandler<T> Resolve<T>() where T : class
        {
            return _lifetimeScope.Resolve<ICommandHandler<T>>();
        }
    }
}