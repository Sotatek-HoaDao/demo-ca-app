﻿using demo_ca_app.Domain.Common;
using demo_ca_app.Domain.Entities;

namespace demo_ca_app.Domain.Events
{
    public class RatingCompletedEvent : DomainEvent
    {
        public RatingCompletedEvent(Rating item)
        {
            Rating = item;
        }

        public Rating Rating { get; }
    }
}
