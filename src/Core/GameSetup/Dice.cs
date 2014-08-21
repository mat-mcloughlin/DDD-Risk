namespace Core.GameSetup
{
    using System;

    public class Dice : IDice
    {
        private readonly Random random;

        public Dice()
        {
            this.random = new Random();
        }

        public int Roll()
        {
            return this.random.Next(1, 6);
        }
    }
}