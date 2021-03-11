using demo_ca_app.Domain.Common;

namespace demo_ca_app.Domain.Entities
{
    public class Movie : AuditableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; } // minute
    }
}
