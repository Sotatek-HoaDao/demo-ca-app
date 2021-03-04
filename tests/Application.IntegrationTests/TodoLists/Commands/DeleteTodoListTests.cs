﻿using demo_ca_app.Application.Common.Exceptions;
using demo_ca_app.Application.TodoLists.Commands.CreateTodoList;
using demo_ca_app.Application.TodoLists.Commands.DeleteTodoList;
using demo_ca_app.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace demo_ca_app.Application.IntegrationTests.TodoLists.Commands
{
    using static Testing;

    public class DeleteTodoListTests : TestBase
    {
        [Test]
        public void ShouldRequireValidTodoListId()
        {
            var command = new DeleteTodoListCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoList()
        {
            var listId = await SendAsync(new CreateTodoListCommand
            {
                Title = "New List"
            });

            await SendAsync(new DeleteTodoListCommand 
            { 
                Id = listId 
            });

            var list = await FindAsync<TodoList>(listId);

            list.Should().BeNull();
        }
    }
}
