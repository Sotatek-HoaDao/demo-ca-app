using demo_ca_app.Application.Movies.Commands.CreateMovie;
using demo_ca_app.Application.Movies.Commands.DeleteMovie;
using demo_ca_app.Application.Movies.Commands.UpdateMovie;
using demo_ca_app.Application.Movies.Queries.GetMovies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace demo_ca_app.WebUI.Controllers
{
    //[Authorize]
    public class MoviesController : ApiControllerBase
    {
        [HttpGet]
        [Authorize("change:movies")]
        public async Task<ActionResult<MoviesVm>> Get()
        {
            return await Mediator.Send(new GetMoviesQuery());
        }

        [HttpPost]
        [Authorize("change:movies")]
        public async Task<ActionResult<int>> Create(CreateMovieCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        [Authorize("change:movies")]
        public async Task<ActionResult> Update(int id, UpdateMovieCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize("change:movies")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteMovieCommand { Id = id });

            return NoContent();
        }
    }
}
