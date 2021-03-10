using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using demo_ca_app.Application.Common.Interfaces;
using demo_ca_app.Application.Ratings.Queries.GetRatings;
using demo_ca_app.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace demo_ca_app.Application.GraphQL.GraphQLQueries
{
    class RatingRepository : IRatingRepository
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public RatingRepository(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<RatingDto> GetAll()
        {
            return
                     _context.Ratings
                   .AsNoTracking()
                   .ProjectTo<RatingDto>(_mapper.ConfigurationProvider)
                   .OrderBy(t => t.Id)
                   .ToList();
            
        }

        public  RatingDto CreateRating(RatingDto rating)
        {
            var entity = new Rating();

            entity.MovieId = rating.MovieId;
            entity.MovieName = rating.MovieName;
            entity.Comment = rating.Comment;
            entity.RatingPoint = rating.RatingPoint;
            entity.UserMail = rating.UserMail;

            _context.Ratings.Add(entity);

            _context.SaveChangesAsync(new CancellationToken());
            
            // Update Id back to dto
            rating.Id = entity.Id;
            return rating;
        }
        public RatingDto UpdateRating(RatingDto rating)
        {
            var entity = _context.Ratings.Find(rating.Id);

            entity.MovieId = rating.MovieId;
            entity.MovieName = rating.MovieName;
            entity.Comment = rating.Comment;
            entity.RatingPoint = rating.RatingPoint;
            entity.UserMail = rating.UserMail;

            _context.Ratings.Update(entity);

            _context.SaveChangesAsync(new CancellationToken());

            // success, return updated obj
            return rating;
        }

        public int DeleteRating(int id)
        {
            var entity = _context.Ratings.Find(id);

            _context.Ratings.Remove(entity);

            _context.SaveChangesAsync(new CancellationToken());

            // success, return 0
            return 0;
        }

    }
}
