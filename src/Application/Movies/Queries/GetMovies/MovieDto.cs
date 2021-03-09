using demo_ca_app.Application.Common.Mappings;
using demo_ca_app.Domain.Entities;
using System.Collections.Generic;

namespace demo_ca_app.Application.Movies.Queries.GetMovies
{
    public class MovieDto : IMapFrom<Movie>
    {
        public MovieDto()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
    }
}
