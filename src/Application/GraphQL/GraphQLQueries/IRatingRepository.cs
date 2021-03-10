using demo_ca_app.Application.Ratings.Queries.GetRatings;
using demo_ca_app.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace demo_ca_app.Application.GraphQL.GraphQLQueries
{
    public interface IRatingRepository
    {
        IEnumerable<RatingDto> GetAll();
        RatingDto CreateRating(RatingDto rating);
        RatingDto UpdateRating(RatingDto rating);
        int DeleteRating(int Id);
    }
}
