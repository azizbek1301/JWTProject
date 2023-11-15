using JWTProject.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTProject.Services.Author
{
    public class AuthorService : IAuthorService
    {
        private readonly  IConfiguration _configuration;
        public AuthorService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public string GenerateToken(UserCreateDto userCreateDto)
        {
            // ma'lumotlar
            var claims = new Claim[]
            {
                // ism
                new Claim("UserName",userCreateDto.UserName),
                // identificator
                new Claim("Password",userCreateDto?.Password),
                // vaqt
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.Now.ToString()),
            };

            // biror algoritm bo'yicha shifrlash

            var credentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                SecurityAlgorithms.HmacSha256
                );

            var token = new JwtSecurityToken(
               _configuration["JWT:ValidIssuer"],
               _configuration["JWT:ValidAudience"],
               claims,
               expires: DateTime.Now.AddSeconds(3),
               signingCredentials: credentials
               );

            var tokenHandler=new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}
