namespace Console
{
    public interface IConsume<in T>
    {
        void Consume(T e);
    }
}