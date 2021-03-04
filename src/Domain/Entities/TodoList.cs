using demo_ca_app.Domain.Common;
using demo_ca_app.Domain.ValueObjects;
using System.Collections.Generic;

namespace demo_ca_app.Domain.Entities
{
    public class TodoList : AuditableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Colour Colour { get; set; } = Colour.White;

        public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
    }
}
