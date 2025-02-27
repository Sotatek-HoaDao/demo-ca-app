﻿using demo_ca_app.Application.Common.Exceptions;
using demo_ca_app.Application.TodoItems.Commands.CreateTodoItem;
using demo_ca_app.Application.TodoItems.Commands.DeleteTodoItem;
using demo_ca_app.Application.TodoLists.Commands.CreateTodoList;
using demo_ca_app.Domain.Entities;
using FluentAssertions;
using System.Threading.Tasks;
using NUnit.Framework;

namespace demo_ca_app.Application.IntegrationTests.TodoItems.Commands
{
    using static Testing;

    public class DeleteTodoItemTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoItemId()
        {
            var command = new DeleteRatingCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoItem()
        {
            var listId = await SendAsync(new CreateMovieCommand
            {
                Title = "New List"
            });

            var itemId = await SendAsync(new CreateRatingCommand
            {
                ListId = listId,
                Title = "New Item"
            });

            await SendAsync(new DeleteRatingCommand
            {
                Id = itemId
            });

            var list = await FindAsync<TodoItem>(listId);

            list.Should().BeNull();
        }
    }
}
