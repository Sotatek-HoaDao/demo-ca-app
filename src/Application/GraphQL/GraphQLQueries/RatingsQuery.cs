using demo_ca_app.Application.GraphQL.GraphQLTypes;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_ca_app.Application.GraphQL.GraphQLQueries
{
    class RatingsQuery : ObjectGraphType
    {
        public RatingsQuery(IRatingRepository repository)
        {
            Field<ListGraphType<RatingType>>(
               "ratings",
               resolve: context => repository.GetAll()
           );
        }
    }
}
