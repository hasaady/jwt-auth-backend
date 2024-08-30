using Authentication.Application.Helpers;
using Authentication.Application.Interfaces.Repostories;
using Authentication.Application.Interfaces.Services;
using Authentication.Infrastructure.Data.Contexts;
using Authentication.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static System.Formats.Asn1.AsnWriter;

namespace Authentication.Infrastructure
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(config.GetConnectionString("DefaultConnection"))
            );

            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<IAuthenticateRepository, AuthenticateRepository>();

            return services;
        }
     }

    public static class DbMigration
    {
        public static void ApplyMigration<TDbContext>(this IServiceScope scope) where TDbContext : DbContext
        {
            using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();
            context.Database.Migrate();
        }
    }
}