using demo_ca_app.Application.Common.Exceptions;
using demo_ca_app.Application.TodoItems.Commands.CreateTodoItem;
using demo_ca_app.Application.Movies.Commands.CreateMovie;
using demo_ca_app.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace demo_ca_app.Application.IntegrationTests.TodoItems.Commands
{
    using static Testing;

    public class CreateTodoItemTests : TestBase
    {
        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new CreateRatingCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<ValidationException>();
        }

        [Test]
        public async Task ShouldCreateTodoItem()
        {
            var userId = await RunAsDefaultUserAsync();

            var listId = await SendAsync(new CreateMovieCommand
            {
                Name = "New List"
            });

            var command = new CreateRatingCommand
            {
                ListId = listId,
                Title = "Tasks"
            };

            var itemId = await SendAsync(command);

            var item = await FindAsync<Rating>(itemId);

            item.Should().NotBeNull();
            item.MovieId.Should().Be(command.ListId);
            item.MovieName.Should().Be(command.Title);
            item.CreatedBy.Should().Be(userId);
            item.Created.Should().BeCloseTo(DateTime.Now, 10000);
            item.LastModifiedBy.Should().BeNull();
            item.LastModified.Should().BeNull();
        }
    }
}
