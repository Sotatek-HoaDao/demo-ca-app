﻿using demo_ca_app.Application.Common.Models;
using demo_ca_app.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace demo_ca_app.Application.Ratings.EventHandlers
{
    public class RatingCreatedEventHandler : INotificationHandler<DomainEventNotification<RatingCreatedEvent>>
    {
        private readonly ILogger<RatingCompletedEventHandler> _logger;

        public RatingCreatedEventHandler(ILogger<RatingCompletedEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(DomainEventNotification<RatingCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var domainEvent = notification.DomainEvent;

            _logger.LogInformation("demo_ca_app Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
