using demo_ca_app.Application.Movies.Commands.CreateMovie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using demo_ca_app.Domain.Entities;
using FluentAssertions;
using demo_ca_app.Application.Tests;
using NUnit.Framework;

namespace demo_ca_app.Application.Movies.Commands.CreateMovie.Tests
{
    using static Testing;
    
    public class CreateMovieCommandHandlerTests : TestBase
    {
        [Test]
        public async Task CreateMovieCommandHandlerTest()
        {

            var userId = await RunAsDefaultUserAsync();

            var command = new CreateMovieCommand
            {
                Name = "Movie test",
                Description = "Movie test description",
                Duration = 120
            };

            var id = await SendAsync(command);

            var list = await FindAsync<Movie>(id);

            list.Should().NotBeNull();
            list.Name.Should().Be(command.Name);
            list.Description.Should().Be(command.Description);
            list.Name.Should().Be(command.Name);
            list.Duration.Should().Be(command.Duration);
        }
    }
}