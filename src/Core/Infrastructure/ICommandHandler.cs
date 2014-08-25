namespace Core.Infrastructure
{
    public interface ICommandHandler<in T> where T : class
    {
        void Handle(T c);
    }
}