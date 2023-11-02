using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Servicify.Application.Services;
using Servicify.Application.Services.Contracts;
using Servicify.DataAccess.Commands;
using Servicify.DataAccess.Commands.Contracts;

namespace Servicify.Application;

public static class DependencyInjection
{
    private const string DefaultConnection = "DefaultConnection";

    public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<IOrganizationService, OrganizationService>();
        services.AddTransient<IServiceService, ServiceService>();
        services.AddTransient<IClientService, ClientService>();
        services.AddTransient<IAppointmentService, AppointmentService>();
        services.AddTransient<IAvailableTimeService, AvailableTimeService>();
    }
}