using Petrix.Domain.Entities;

namespace Petrix.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(User user);
    }
}