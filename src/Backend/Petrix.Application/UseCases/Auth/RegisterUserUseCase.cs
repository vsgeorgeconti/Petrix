using Petrix.Application.Common;
using Petrix.Application.DTOs.Auth;
using Petrix.Application.Repositories;
using Petrix.Domain.Entities;

namespace Petrix.Application.UseCases.Auth
{
    public class RegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public RegisterUserUseCase(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public async Task<ApiResponse<RegisterResponse>> ExecuteAsync(RegisterRequest request)
        {

            if (string.IsNullOrWhiteSpace(request.Name))
                return new ApiResponse<RegisterResponse>(false, "NAME_NOT_FOUND", null, "Favor preencher o nome do usuario.");

            if (string.IsNullOrWhiteSpace(request.Email))
                return new ApiResponse<RegisterResponse>(false, "EMAIL_NOT_FOUND", null, "Favor preencher o email do usuario.");

            if (string.IsNullOrWhiteSpace(request.Password))
                return new ApiResponse<RegisterResponse>(false, "PASSWORD_NOT_FOUND", null, "Favor preencher a senha do usuario.");

            if (string.IsNullOrWhiteSpace(request.ConfirmPassword))
                return new ApiResponse<RegisterResponse>(false, "PASSWORD_NOT_FOUND",null, "Favor preencher a confirmação da senha do usuario.");

            if (request.Password.Trim() != request.ConfirmPassword.Trim())
                return new ApiResponse<RegisterResponse>(false, "PASSWORD_NOT_MATCH", null, "Senhas não coincidem.");

            var email = request.Email.Trim().ToLowerInvariant();
            var exists = await _userRepository.GetByEmailAsync(email);
            if (exists is not null)
                return new ApiResponse<RegisterResponse>(false, "EMAIL_EXISTS", null, "Email já cadastrado.");

            var passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = User.Create(request.Name.Trim(), email, passwordHash);

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            var response = new RegisterResponse(user.Id, user.Name, user.Email);
            return new ApiResponse<RegisterResponse>(true, "", response, "Registro realizado com sucesso.");

        }
    }
}