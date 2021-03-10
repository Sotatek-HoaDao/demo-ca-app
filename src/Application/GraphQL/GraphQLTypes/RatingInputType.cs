using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_ca_app.Application.GraphQL.GraphQLTypes
{
    class RatingInputType : InputObjectGraphType
    {
        public RatingInputType()
        {
            Name = "ratingInput";
            Field<NonNullGraphType<StringGraphType>>("Id");
            Field<NonNullGraphType<StringGraphType>>("MovieId");
            Field<NonNullGraphType<StringGraphType>>("MovieName");
            Field<NonNullGraphType<StringGraphType>>("Comment");
            Field<NonNullGraphType<StringGraphType>>("RatingPoint");
            Field<NonNullGraphType<StringGraphType>>("UserMail");
        }
    }
}
