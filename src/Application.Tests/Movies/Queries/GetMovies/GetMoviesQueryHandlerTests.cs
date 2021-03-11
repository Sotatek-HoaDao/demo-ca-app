using demo_ca_app.Application.Movies.Queries.GetMovies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo_ca_app.Application.Tests;
using FluentAssertions;
using demo_ca_app.Domain.Entities;
using NUnit.Framework;

namespace demo_ca_app.Application.Movies.Queries.GetMovies.Tests
{
    using static Testing;
    public class GetMoviesQueryHandlerTests : TestBase
    {
        [Test]
        public async Task GetMoviesQueryHandlerTest()
        {
            await AddAsync(new Movie
            {
                Name = "Movie1", Description = "Description movie1",Duration = 120,
            });

            var query = new GetMoviesQuery();

            var result = await SendAsync(query);

            result.Lists.Should().HaveCount(1);
        }

    }
}