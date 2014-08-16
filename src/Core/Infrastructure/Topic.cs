namespace Core.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Topic
    {
        private readonly IDictionary<Type, Action<object>> handlers;

        public Topic()
        {
            this.handlers = new Dictionary<Type, Action<object>>();
            this.Events = new List<object>();
            this.Register();
        }

        public List<object> Events { get; private set; }

        protected void Raise(object @event)
        {
            this.Dispatch(@event);
            this.Events.Add(@event);
        }

        private void Register()
        {
            var whenMethods = this.GetType()
                .GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(m => m.Name == "When")
                .Select(m => new
                    {
                        Method = m,
                        MessageType = m.GetParameters().Single().ParameterType
                    });

            foreach (var apply in whenMethods)
            {
                var applyMethod = apply.Method;
                this.handlers.Add(apply.MessageType, m => applyMethod.Invoke(this, new[] { m }));
            }
        }

        private void Dispatch(object eventMessage)
        {
            if (this.handlers.Keys.Contains(eventMessage.GetType()))
            {
                this.handlers[eventMessage.GetType()](eventMessage);
            }
        }
    }
}
