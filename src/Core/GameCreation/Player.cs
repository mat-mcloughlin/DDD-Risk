namespace Core.GameCreation
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }
    }
}