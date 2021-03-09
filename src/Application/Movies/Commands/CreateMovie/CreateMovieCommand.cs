using demo_ca_app.Application.Common.Interfaces;
using demo_ca_app.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace demo_ca_app.Application.Movies.Commands.CreateMovie
{
    public class CreateMovieCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
    }

    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateMovieCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var entity = new Movie();

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Duration = request.Duration;

            _context.Movies.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
