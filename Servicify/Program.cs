using System.Reflection;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.EventLog;
using Microsoft.OpenApi.Models;
using Servicify.DataAccess;

const string debugEnvironmentName = "Debug";
const string loggingSectionKey = "Logging";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opt => { opt.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>(); });

builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Version = "0.0.1",
                Title = "BestBy API",
                Description = "BestBy API to track products that are about to expire",
                Contact = new OpenApiContact
                {
                    Name = "Tourmaline Core",
                    Url = new Uri("https://www.tourmalinecore.com/"),
                },
            }
        );

    c.AddSecurityDefinition("Bearer",
            new OpenApiSecurityScheme
            {
                Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer",
            }
        );

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer",
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,
                            },
                            new List<string>()
                        },
                    }
        );
}
    );

builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    var env = hostingContext.HostingEnvironment;
    var reloadOnChange = hostingContext.Configuration.GetValue("hostBuilder:reloadConfigOnChange", true);

    config.AddJsonFile("appsettings.json", true, reloadOnChange)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true, reloadOnChange)
        .AddJsonFile("appsettings.Active.json", true, reloadOnChange)
        .AddJsonFile("swagger.json", true, reloadOnChange);

    if (env.IsDevelopment() && !string.IsNullOrEmpty(env.ApplicationName))
    {
        var appAssembly = Assembly.Load(new AssemblyName(env.ApplicationName));
        config.AddUserSecrets(appAssembly, true);
    }

    config.AddEnvironmentVariables();
    config.AddCommandLine(args);
}
    );

var configuration = builder.Configuration;

builder.Services.AddPersistence(configuration);

builder.Host.ConfigureLogging((hostingContext, logging) =>
{
    var isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    if (isWindows)
    {
        logging.AddFilter<EventLogLoggerProvider>(level => level >= LogLevel.Warning);
    }

    logging.AddConfiguration(hostingContext.Configuration.GetSection(loggingSectionKey));
    logging.AddConsole();
    logging.AddDebug();
    logging.AddEventSourceLogger();

    if (isWindows)
    {
        logging.AddEventLog();
    }

    logging.Configure(options =>
    {
        options.ActivityTrackingOptions = ActivityTrackingOptions.SpanId
                                          | ActivityTrackingOptions.TraceId
                                          | ActivityTrackingOptions.ParentId;
    }
        );
}
    );

var app = builder.Build();

app.UseCors(
        corsPolicyBuilder => corsPolicyBuilder
            .AllowAnyHeader()
            .SetIsOriginAllowed(_ => true)
            .AllowAnyMethod()
            .AllowAnyOrigin()
    );
app.UseStaticFiles();

if (builder.Environment.EnvironmentName == "Debug")
{
    app.UseSwagger();
    app.UseSwaggerUI(option => { option.SwaggerEndpoint("/swagger/v1/swagger.json", "Best By API"); });
}

app.UseSwagger(option => { option.RouteTemplate = "api/swagger/{documentName}/swagger.json"; });

app.UseSwaggerUI(option =>
{
    option.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Best By API");
    option.RoutePrefix = "api/swagger";
}
    );

using (var serviceScope = app.Services.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
    await context.Database.MigrateAsync();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
