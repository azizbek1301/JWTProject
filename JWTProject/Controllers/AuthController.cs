using JWTProject.Entities;
using JWTProject.Models;
using JWTProject.Services.Author;
using JWTProject.Services.Security;
using JWTProject.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace JWTProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthorService _authService;
        public AuthController(IUserService userService,IAuthorService authorService)
        {
            _userService = userService;
            _authService = authorService;
        }

        [HttpPost]
        public async ValueTask<IActionResult> Login(UserCreateDto createDto)
        {
            var users=await _userService.GetUsersAsync();
            User? user= users.FirstOrDefault(x=>x.UserName==createDto.UserName && x.PasswordHash==Hash512.ComputeHash512(createDto.Password));
            if (user == null)
            {
                return NotFound("Login yoki password xato");
            }
            string token = _authService.GenerateToken(createDto);
            return Ok(token);
        }
    }
}
