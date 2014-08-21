namespace Core.Workflows
{
    using Core.GameSetup;
    using Core.GameSetup.Games;

    public class TurnWorkFlow : IObserve<GameStarted>, IObserve<TurnEnded>
    {
        public void Observe(GameStarted @event)
        {
            
        }

        public void Observe(TurnEnded @event)
        {
            
        }
    }

    public interface IObserve<T>
    {
        void Observe(T @event);
    }
}
