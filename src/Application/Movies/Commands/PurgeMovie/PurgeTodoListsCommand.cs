using demo_ca_app.Application.Common.Interfaces;
using demo_ca_app.Application.Common.Security;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace demo_ca_app.Application.Movies.Commands.PurgeMovie
{
    [Authorize(Roles = "Administrator")]
    [Authorize(Policy = "CanPurge")]
    public class PurgeMovieCommand : IRequest
    {
    }

    public class PurgeTodoListsCommandHandler : IRequestHandler<PurgeMovieCommand>
    {
        private readonly IApplicationDbContext _context;

        public PurgeTodoListsCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(PurgeMovieCommand request, CancellationToken cancellationToken)
        {
            _context.Movies.RemoveRange(_context.Movies);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
