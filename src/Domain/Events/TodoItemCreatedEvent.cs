using demo_ca_app.Domain.Common;
using demo_ca_app.Domain.Entities;

namespace demo_ca_app.Domain.Events
{
    public class TodoItemCreatedEvent : DomainEvent
    {
        public TodoItemCreatedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
