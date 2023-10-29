using Microsoft.EntityFrameworkCore;
using Servicify.Core;

namespace Servicify.DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public AppDbContext()
    {
    }

    public DbSet<Organization> Organizations { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<AvailableTime> AvailableTimes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Service>()
            .HasOne(s => s.Organization)
            .WithMany(o => o.Services)
            .HasForeignKey(s => s.OrganizationId);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Service)
            .WithMany(s => s.Appointments)
            .HasForeignKey(a => a.ServiceId);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Client)
            .WithMany(c => c.Appointments)
            .HasForeignKey(a => a.ClientId);

        modelBuilder.Entity<AvailableTime>()
            .HasOne(t => t.Service)
            .WithMany(s => s.AvailableTimes)
            .HasForeignKey(t => t.ServiceID);
    }
}