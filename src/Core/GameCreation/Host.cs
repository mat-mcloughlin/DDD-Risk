namespace Core.GameCreation
{
    using System;

    public class Host
    {
        public Host(Guid id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public string Name { get; private set; }

        public Guid Id { get; private set; }
    }
}