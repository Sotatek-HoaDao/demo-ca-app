using demo_ca_app.Application.GraphQL.GraphQLTypes;
using demo_ca_app.Application.Ratings.Queries.GetRatings;
using GraphQL;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_ca_app.Application.GraphQL.GraphQLQueries
{
    class RatingMutation : ObjectGraphType
    {
        public RatingMutation(IRatingRepository repository)
        {
            Field<RatingType>(
                "createRating",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<RatingInputType>> { Name = "rating" }),
                resolve: context =>
                {
                    var rating = context.GetArgument<RatingDto>("rating");
                    return repository.CreateRating(rating);
                }
            );

            Field<RatingType>(
                "updateRating",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<RatingInputType>> { Name = "rating" }),
                resolve: context =>
                {
                    var rating = context.GetArgument<RatingDto>("rating");
                    
                    return repository.UpdateRating(rating);
                }
            );

            Field<IntGraphType>(
                "deleteRating",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "ratingId" }),
                resolve: context =>
                {
                    var ratingId = context.GetArgument<int>("ratingId");

                    return repository.DeleteRating(ratingId);
                }
            );
        }
    }
}
