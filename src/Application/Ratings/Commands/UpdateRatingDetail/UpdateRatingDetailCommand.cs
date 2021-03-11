using demo_ca_app.Application.Common.Exceptions;
using demo_ca_app.Application.Common.Interfaces;
using demo_ca_app.Domain.Entities;
using demo_ca_app.Domain.Enums;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace demo_ca_app.Application.Ratings.Commands.UpdateRatingDetail
{
    public class UpdateRatingDetailCommand : IRequest
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public string MovieName { get; set; }

        public string Comment { get; set; }
        public int RatingPoint { get; set; }
        public string UserMail { get; set; }
    }

    public class UpdateRatingDetailCommandHandler : IRequestHandler<UpdateRatingDetailCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateRatingDetailCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateRatingDetailCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Ratings.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Rating), request.Id);
            }

            entity.MovieId = request.MovieId;
            entity.MovieName = request.MovieName;
            entity.Comment = request.Comment;
            entity.RatingPoint = (int)request.RatingPoint;
            entity.UserMail = request.UserMail;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
