namespace Core.SetupPhase
{
    using System;

    public class Dice : IDice
    {
        private readonly Random _random;

        public Dice()
        {
            this._random = new Random();
        }

        public int Roll()
        {
            return this._random.Next(1, 6);
        }
    }
}