using Microsoft.Extensions.DependencyInjection;
using Petrix.Application.UseCases.Auth;
using Microsoft.Extensions.Configuration;
using Petrix.Application.Common;

namespace Petrix.Application.DependencyInjection
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<RegisterUserUseCase>();
            services.AddScoped<LoginUseCase>();
            
            return services;
        }

        

        public static IServiceCollection AddJwtSettings(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
            return services;
        }



    }
}