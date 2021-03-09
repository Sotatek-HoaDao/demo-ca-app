using demo_ca_app.Application.Common.Exceptions;
using demo_ca_app.Application.Common.Interfaces;
using demo_ca_app.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace demo_ca_app.Application.Ratings.Commands.UpdateRating
{
    public class UpdateRatingCommand : IRequest
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool Done { get; set; }
    }

    public class UpdateTodoItemCommandHandler : IRequestHandler<UpdateRatingCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRatingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Ratings.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Rating), request.Id);
            }

            entity.MovieName = request.Title;
            //entity.Done = request.Done;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
