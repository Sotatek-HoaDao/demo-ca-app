using AutoMapper;
using AutoMapper.QueryableExtensions;
using demo_ca_app.Application.Common.Interfaces;
using demo_ca_app.Application.Common.Mappings;
using demo_ca_app.Application.Common.Models;
using demo_ca_app.Application.Movies.Queries.GetMovies;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace demo_ca_app.Application.Ratings.Queries.GetRatingWithPagination
{
    public class GetRatingWithPaginationQuery : IRequest<PaginatedList<RatingDto>>
    {
        public int ListId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetTodoItemsWithPaginationQueryHandler : IRequestHandler<GetRatingWithPaginationQuery, PaginatedList<RatingDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTodoItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<RatingDto>> Handle(GetRatingWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Ratings
                .Where(x => x.MovieId == request.ListId)
                .OrderBy(x => x.MovieName)
                .ProjectTo<RatingDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize); ;
        }
    }
}
