using Petrix.Domain.Entities;

namespace Petrix.Application.Services
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
    }
}