using demo_ca_app.Application.Common.Exceptions;
using demo_ca_app.Application.TodoItems.Commands.CreateTodoItem;
using demo_ca_app.Application.TodoItems.Commands.UpdateTodoItem;
using demo_ca_app.Application.TodoLists.Commands.CreateTodoList;
using demo_ca_app.Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;
using System;

namespace demo_ca_app.Application.IntegrationTests.TodoItems.Commands
{
    using static Testing;

    public class UpdateTodoItemTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoItemId()
        {
            var command = new UpdateRatingCommand
            {
                Id = 99,
                Title = "New Title"
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateTodoItem()
        {
            var userId = await RunAsDefaultUserAsync();

            var listId = await SendAsync(new CreateMovieCommand
            {
                Title = "New List"
            });

            var itemId = await SendAsync(new CreateRatingCommand
            {
                ListId = listId,
                Title = "New Item"
            });

            var command = new UpdateRatingCommand
            {
                Id = itemId,
                Title = "Updated Item Title"
            };

            await SendAsync(command);

            var item = await FindAsync<TodoItem>(itemId);

            item.Title.Should().Be(command.Title);
            item.LastModifiedBy.Should().NotBeNull();
            item.LastModifiedBy.Should().Be(userId);
            item.LastModified.Should().NotBeNull();
            item.LastModified.Should().BeCloseTo(DateTime.Now, 1000);
        }
    }
}
