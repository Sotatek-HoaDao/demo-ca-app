using demo_ca_app.Domain.Common;
using System.Threading.Tasks;

namespace demo_ca_app.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
