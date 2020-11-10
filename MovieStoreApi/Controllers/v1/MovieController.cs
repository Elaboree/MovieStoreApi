using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Service.v1.Command;
using MovieStoreApi.Service.v1.Query;
using System.Threading.Tasks;

namespace MovieStoreApi.Controllers.v1
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : BaseController
    {
        private readonly IMediator _mediator;
        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("Movies")]
        public async Task<IActionResult> GetAllMovies([FromQuery] GetMoviesQuery request)
        {
            var result = await _mediator.Send(request);
            return Json(result);
        }

        [HttpGet("Movie")]
        public async Task<IActionResult> GetMovie([FromQuery] GetMovieQuery request)
        {
            var result = await _mediator.Send(request);
            return Json(result);
        }

        [HttpPost("Recommend")]
        public async Task<IActionResult> SendRecommendation([FromQuery] SendRecommendationQuery request)
        {
            var result = await _mediator.Send(request);
            return Json(result);
        }

        [HttpPost("AddCritic")]
        public async Task<IActionResult> AddMovieCritic([FromQuery] AddMovieCriticCommand request)
        {
            var result = await _mediator.Send(request);
            return Json(result);
        }
    }
}
