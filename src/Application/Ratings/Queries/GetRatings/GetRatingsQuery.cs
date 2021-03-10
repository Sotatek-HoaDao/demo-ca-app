using AutoMapper;
using AutoMapper.QueryableExtensions;
using demo_ca_app.Application.Common.Interfaces;
using demo_ca_app.Application.Common.Mappings;
using demo_ca_app.Application.Common.Models;
using demo_ca_app.Application.Movies.Queries.GetMovies;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace demo_ca_app.Application.Ratings.Queries.GetRatings
{
    public class GetRatingsQuery : IRequest<RatingsVm>
    {
    }

    public class GetRatingsQueryHandler : IRequestHandler<GetRatingsQuery, RatingsVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRatingsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RatingsVm> Handle(GetRatingsQuery request, CancellationToken cancellationToken)
        {
            return new RatingsVm
            {
                Lists = await _context.Ratings
                    .AsNoTracking()
                    .ProjectTo<RatingDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Id)
                    .ToListAsync(cancellationToken)
            };
            
        }
    }
}
