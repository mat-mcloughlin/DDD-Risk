namespace Core.Infrastructure
{
    public interface ICommandHandlerResolver
    {
        ICommandHandler<T> Resolve<T>() where T : class;
    }
}