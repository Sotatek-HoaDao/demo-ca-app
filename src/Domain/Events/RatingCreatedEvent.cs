using demo_ca_app.Domain.Common;
using demo_ca_app.Domain.Entities;

namespace demo_ca_app.Domain.Events
{
    public class RatingCreatedEvent : DomainEvent
    {
        public RatingCreatedEvent(Rating item)
        {
            Rating = item;
        }

        public Rating Rating { get; }
    }
}
