using Microsoft.EntityFrameworkCore;
using Servicify.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
var configuration = builder.Configuration;

builder.Services.AddPersistence(configuration);


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
    app.UseSwaggerUI(option => { option.SwaggerEndpoint("/swagger/v1/swagger.json", "API"); });
}

app.UseSwagger();

app.UseSwaggerUI();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.MapRazorPages();

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
