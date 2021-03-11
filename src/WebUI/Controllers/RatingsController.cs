using demo_ca_app.Application.Common.Models;
using demo_ca_app.Application.Ratings.Commands.CreateRating;
using demo_ca_app.Application.Ratings.Commands.DeleteRating;
using demo_ca_app.Application.Ratings.Commands.UpdateRating;
using demo_ca_app.Application.Ratings.Commands.UpdateRatingDetail;
using demo_ca_app.Application.Ratings.Queries.GetRatings;
using demo_ca_app.Application.Movies.Queries.GetMovies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace demo_ca_app.WebUI.Controllers
{
    /// <summary>
    /// This controller is kept to generate dto object
    /// </summary>
    [Authorize]
    [Authorize("read:ratings")]
    public class RatingsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<RatingsVm>> Get()
        {
            return await Mediator.Send(new GetRatingsQuery());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateRatingCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateRatingCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> UpdateRatingDetails(int id, UpdateRatingDetailCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteRatingCommand { Id = id });

            return NoContent();
        }
    }
}
