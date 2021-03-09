using demo_ca_app.Application.Common.Interfaces;
using demo_ca_app.Domain.Entities;
using demo_ca_app.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace demo_ca_app.Application.Ratings.Commands.CreateRating
{
    public class CreateRatingCommand : IRequest<int>
    {
        public int ListId { get; set; }

        public string Title { get; set; }
    }

    public class CreateTodoItemCommandHandler : IRequestHandler<CreateRatingCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateRatingCommand request, CancellationToken cancellationToken)
        {
            //var entity = new TodoItem
            //{
            //    ListId = request.ListId,
            //    Title = request.Title,
            //    Done = false
            //};

            //entity.DomainEvents.Add(new TodoItemCreatedEvent(entity));

            //_context.TodoItems.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return 0;
        }
    }
}
