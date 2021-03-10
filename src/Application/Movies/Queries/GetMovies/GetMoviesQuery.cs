using AutoMapper;
using AutoMapper.QueryableExtensions;
using demo_ca_app.Application.Common.Interfaces;
using demo_ca_app.Application.Common.Security;
using demo_ca_app.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace demo_ca_app.Application.Movies.Queries.GetMovies
{
    public class GetMoviesQuery : IRequest<MoviesVm>
    {
    }

    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, MoviesVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetMoviesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MoviesVm> Handle(GetMoviesQuery request, CancellationToken cancellationToken)
        {
            return new MoviesVm
            {
                Lists = await _context.Movies
                    .AsNoTracking()
                    .ProjectTo<MovieDto>(_mapper.ConfigurationProvider)
                    .OrderBy(t => t.Id)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
