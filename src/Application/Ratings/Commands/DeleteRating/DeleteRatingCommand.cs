using demo_ca_app.Application.Common.Exceptions;
using demo_ca_app.Application.Common.Interfaces;
using demo_ca_app.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace demo_ca_app.Application.Ratings.Commands.DeleteRating
{
    public class DeleteRatingCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteRatingCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRatingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Ratings.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Rating), request.Id);
            }

            _context.Ratings.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
