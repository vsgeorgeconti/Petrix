using Microsoft.Extensions.DependencyInjection;
using Petrix.Application.UseCases.Auth;

namespace Petrix.Application.DependencyInjection
{
    public static class ApplicationDependencyInjection
    {
         public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<RegisterUserUseCase>();
            return services;
        }
    }
}