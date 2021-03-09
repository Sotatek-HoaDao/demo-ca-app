using demo_ca_app.Application.Common.Exceptions;
using demo_ca_app.Application.Movies.Commands.CreateMovie;
using demo_ca_app.Application.Movies.Commands.DeleteMovie;
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
            var command = new DeleteMovieCommand { Id = 99 };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().Throw<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoList()
        {
            var listId = await SendAsync(new CreateMovieCommand
            {
                Name = "New List"
            });

            await SendAsync(new DeleteMovieCommand
            { 
                Id = listId 
            });

            var list = await FindAsync<Movie>(listId);

            list.Should().BeNull();
        }
    }
}
