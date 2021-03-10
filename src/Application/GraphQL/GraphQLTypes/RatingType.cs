using demo_ca_app.Application.Ratings.Queries.GetRatings;
using demo_ca_app.Domain.Entities;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_ca_app.Application.GraphQL.GraphQLTypes
{
    class RatingType : ObjectGraphType<RatingDto>
    {
        public RatingType()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("Id property from the rating object.");
            Field(x => x.MovieId).Description("MovieId property from the rating object.");
            Field(x => x.MovieName).Description("MovieName property from the rating object.");
            Field(x => x.Comment).Description("Comment property from the rating object.");
            Field(x => x.RatingPoint).Description("MovieId property from the rating object.");
            Field(x => x.UserMail).Description("UserMail property from the rating object.");
        }
    }
}
