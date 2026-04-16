using Microsoft.Extensions.DependencyInjection;
using Petrix.Application.UseCases.Auth;
using Microsoft.Extensions.Configuration;
using Petrix.Application.Common;
using Petrix.Application.UseCases.Customer;
using Petrix.Application.UseCases.Pet;

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
            services.AddScoped<CreatePetUseCase>();
            services.AddScoped<GetPetByIdUseCase>();
            services.AddScoped<GetAllPetsUseCase>();
            services.AddScoped<UpdatePetUseCase>();
            services.AddScoped<DeletePetUseCase>();
            services.AddScoped<GetPetsByCustomerIdUseCase>();
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