namespace Core.Infrastructure
{
    public interface IObserve<in T> where T : class
    {
        void Observe(T e);
    }
}