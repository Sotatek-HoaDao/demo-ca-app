using demo_ca_app.Application.GraphQL.GraphQLQueries;
using GraphQL.Types;
using GraphQL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_ca_app.Application.GraphQL.GraphQLSchema
{
    public class RatingSchema : Schema
    {
        public RatingSchema(IServiceProvider provider)
        : base(provider)
        {
            Query = provider.GetRequiredService<RatingsQuery>();
            Mutation = provider.GetRequiredService<RatingMutation>();
        }
    }
}
