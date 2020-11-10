using MediatR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Domain;
using MovieStoreApi.Service.v1.Query;
using MovieStoreApi.Service.Models;
using MovieStoreApi.Service.v1.Command;

namespace MovieStoreApi.Controllers.v1
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly UserManager<User> _userManager;

        private readonly IMediator _mediator;
        public UserController(UserManager<User> userManager, IMediator mediator)
        {
            _userManager = userManager;
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel registerModel)
        {
            var result = await  _mediator.Send(new UserRegisterCommand { UserRegisterModel = registerModel });
            return Json(result);
        }

        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] AuthenticateQuery authenticateQuery)
        {
            var result = await _mediator.Send(authenticateQuery);
            return Json(result);
        }
    }
}
