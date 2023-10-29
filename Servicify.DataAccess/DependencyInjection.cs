using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Servicify.DataAccess
{
    public static class DependencyInjection
    {
        private const string DefaultConnection = "DefaultConnection";

        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString(DefaultConnection);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<AppDbContext>();
        }
    }
}
