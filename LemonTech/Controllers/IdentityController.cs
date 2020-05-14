using System.Threading.Tasks;
using Lemontech.DataLayer.Models;
using LemonTech.Repository.Identity.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LtTask.Controllers
{
    [Route("api")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> CreateUser([FromBody] SignUpOptions options)
        {
            var result = await _identityService.SignUp(options);

            if (!result.Succeeded)
                return BadRequest();

            return Ok(result);
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> Login([FromBody] Credentials options)
        {
            var result = await _identityService.Login(options);

            return Ok(result);
        }
    }
}