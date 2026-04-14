using Petrix.Application.Common;
using Petrix.Application.DTOs.Auth;
using Petrix.Application.Repositories;
using Petrix.Application.Services;

namespace Petrix.Application.UseCases.Auth
{
    public class LoginUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginUseCase(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<ApiResponse<LoginResponse>> LoginAsync(LoginRequest request)
        {

            if (string.IsNullOrWhiteSpace(request.Email))
                return new ApiResponse<LoginResponse>(false, "EMAIL_NOT_FOUND", null, "Favor preencher o email do login.");
            if (string.IsNullOrWhiteSpace(request.Password))
                return new ApiResponse<LoginResponse>(false, "PASSWORD_NOT_FOUND", null, "Favor preencher a senha do login.");

            var email = request.Email.Trim().ToLowerInvariant();
            var user = await _userRepository.GetByEmailAsync(email);


            if (user is null)
                return new ApiResponse<LoginResponse>(false, "LOGIN_NOT_EXISTS", null, "Email não cadastrado, favor realizar o cadastro.");

            var isPasswordValid = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!isPasswordValid)
                return new ApiResponse<LoginResponse>(false, "PASSWORD_INCORRECT", null, "Senha incorreta, favor verificar.");

            var token = _tokenService.GenerateAccessToken(user);

            if (string.IsNullOrWhiteSpace(token))
                return new ApiResponse<LoginResponse>(false, "TOKEN_ERROR", null, "Erro ao gerar o token, tente novamente.");

            var response = new LoginResponse
            {
                AccessToken = token
            };

            return new ApiResponse<LoginResponse>(true, "SUCCESS", response, "Login realizado com sucesso.");
        }

    }
}