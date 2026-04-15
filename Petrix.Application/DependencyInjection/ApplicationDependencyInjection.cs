using Microsoft.Extensions.DependencyInjection;
using Petrix.Application.UseCases.Auth;
using Microsoft.Extensions.Configuration;
using Petrix.Application.Common;
using Petrix.Application.UseCases.Customer;

namespace Petrix.Application.DependencyInjection
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<RegisterUserUseCase>();
            services.AddScoped<LoginUseCase>();
            services.AddScoped<CreateCustomerUseCase>();
            services.AddScoped<GetAllCustomersUseCase>();
            services.AddScoped<GetCustomerByIdUseCase>();
            services.AddScoped<UpdateCustomerUseCase>();
            services.AddScoped<DeleteCustomerUseCase>();
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