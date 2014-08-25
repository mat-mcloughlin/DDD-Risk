namespace Core.Infrastructure
{
    using System.Reflection;

    public class CommandDispatcher
    {
        private readonly MethodInfo _dispatchMethodInfo;

        private readonly ICommandHandlerResolver _handlerResolver;

        public CommandDispatcher(ICommandHandlerResolver handlerResolver)
        {
            _handlerResolver = handlerResolver;
            _dispatchMethodInfo = GetType()
            .GetMethod("DispatchGeneric", BindingFlags.Instance | BindingFlags.NonPublic);
        }

        public void Dispatch(object command)
        {
            _dispatchMethodInfo
            .MakeGenericMethod(command.GetType())
            .Invoke(this, new[] { command });
        }

        void DispatchGeneric<T>(T command) where T : class
        {
            var commandHandler = _handlerResolver.Resolve<T>();
            if (commandHandler == null)
            {
                throw new NoCommandHandlerFoundException();
            }

            commandHandler.Handle(command);
        }
    }
}
