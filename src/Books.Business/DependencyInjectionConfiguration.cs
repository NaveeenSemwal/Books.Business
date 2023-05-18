using Books.Business.Interfaces;
using Books.Business.Model.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Books.Business
{
    public static class DependencyInjectionConfiguration
    {
        /// <summary>Configure App Services</summary>
        /// <param name="services">Service collection</param>
        /// <param name="configuration">Application configuration</param>
        public static void ConfigureAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            // http request should be AddScoped

            services.AddScoped<IBooksServive, BooksServive>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IRolesService, RolesService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IPhotoService, PhotoService>();

            services.Configure<CloudinarySetting>(configuration.GetSection("CloudinarySetting"));
            services.TryAddSingleton<CloudinarySetting>();
        }

    }
}
