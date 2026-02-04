using Microsoft.EntityFrameworkCore;
using Turnify.Domain.Entities;

namespace Turnify.Infrastructure.Persistence;

public class TurnifyDbContext : DbContext
{
    public TurnifyDbContext(DbContextOptions<TurnifyDbContext> options)
        : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Professional> Professionals => Set<Professional>();
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
      
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Professional>()
            .HasOne(p => p.User)
            .WithOne()
            .HasForeignKey<Professional>(p => p.UserId);

        modelBuilder.Entity<Client>()
            .HasOne(c => c.User)
            .WithOne()
            .HasForeignKey<Client>(c => c.UserId);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Professional)
            .WithMany()
            .HasForeignKey(a => a.ProfessionalId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Appointment>()
            .HasOne(a => a.Client)
            .WithMany()
            .HasForeignKey(a => a.ClientId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}
