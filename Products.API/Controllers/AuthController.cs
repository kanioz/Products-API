using Microsoft.AspNetCore.Mvc;
using Products.API.Service;
using Products.API.ViewModel;

namespace Products.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("token")]
        public IActionResult Token([FromBody] AuthenticateRequest model)
        {
            var user = _userService.Authenticate(model);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorret" });

            return Ok(user);
        }
    }
}
