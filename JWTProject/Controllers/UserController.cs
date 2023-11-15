using JWTProject.Models;
using JWTProject.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpGet]
        public async ValueTask<IActionResult>GetAllAsync()
        {
            try
            {
                var users = await _userService.GetUsersAsync();
                return Ok(users);   
            }
            catch (Exception ex)
            {
                return NotFound("User topilmadi");
            }
        }
        [HttpPost]
        public async ValueTask<IActionResult>PostAsync(UserCreateDto createDto)
        {
            var res=await _userService.CreateAsync(createDto);
            if (res)
                return Ok("Success");
            return BadRequest("Don't create");
        }
    }
}
