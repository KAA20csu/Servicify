using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Servicify.DataAccess.Commands;
using Servicify.DataAccess.Commands.Contracts;
using Servicify.DataAccess.Queries;
using Servicify.DataAccess.Queries.Contracts;

namespace Servicify.DataAccess;

public static class DependencyInjection
{
    private const string DefaultConnection = "DefaultConnection";

    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString(DefaultConnection);

        services.AddDbContext<AppDbContext>(options => { options.UseNpgsql(connectionString); });

        services.AddScoped<AppDbContext>();
        services.AddTransient<IOrganizationCommand, OrganizationCommand>();
        services.AddTransient<IServiceCommand, ServiceCommand>();
        services.AddTransient<IClientCommand, ClientCommand>();
        services.AddTransient<IAppointmentCommand, AppointmentCommand>();
        services.AddTransient<IAvailableTimeCommand, AvailableTimeCommand>();

        services.AddTransient<IOrganizationQuery, OrganizationQuery>();
        services.AddTransient<IServiceQuery, ServiceQuery>();
        services.AddTransient<IClientQuery, ClientQuery>();
        services.AddTransient<IAppointmentQuery, AppointmentQuery>();
        services.AddTransient<IAvailableTimeQuery, AvailableTimeQuery>();
    }
}