using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestfulApi.Entities;
using RestfulApi.Services.FakeServices;

namespace RestfulApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        private readonly IFakeService _fakeService;

        public AuthsController(IFakeService fakeService)
        {
            _fakeService = fakeService;
        }

        [HttpPost("FakeLogin")]
        public IActionResult FakeLogin([FromBody] FakeUser fakeUser)
        {
            var user = _fakeService.Authenticate(fakeUser.Username, fakeUser.Password);
            if (user == null) 
                return Unauthorized();

            return Ok("Fake login successfully");
        }
    }
}
