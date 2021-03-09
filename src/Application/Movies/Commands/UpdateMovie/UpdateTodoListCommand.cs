using demo_ca_app.Application.Common.Exceptions;
using demo_ca_app.Application.Common.Interfaces;
using demo_ca_app.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace demo_ca_app.Application.Movies.Commands.UpdateMovie
{
    public class UpdateMovieCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
    }

    public class UpdateTodoListCommandHandler : IRequestHandler<UpdateMovieCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateTodoListCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Movies.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Movie), request.Id);
            }

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Duration = request.Duration;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
