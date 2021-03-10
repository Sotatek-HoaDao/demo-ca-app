using AutoMapper;
using demo_ca_app.Application.Common.Mappings;
using demo_ca_app.Domain.Entities;

namespace demo_ca_app.Application.Ratings.Queries.GetRatings
{
    public class RatingDto : IMapFrom<Rating>
    {
        public int Id { get; set; }

        public int MovieId { get; set; }

        public string MovieName { get; set; }

        public string Comment { get; set; }

        public int RatingPoint { get; set; }

        public string UserMail { get; set; }

    }
}
