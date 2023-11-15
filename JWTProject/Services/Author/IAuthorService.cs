using JWTProject.Models;

namespace JWTProject.Services.Author
{
    public interface IAuthorService
    {
        public string GenerateToken(UserCreateDto userCreateDto);
    }
}
