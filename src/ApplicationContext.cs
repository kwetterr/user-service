using System;
using kwetter_authentication.Models;
using Microsoft.EntityFrameworkCore;

namespace kwetter_authentication
{
  public class ApplicationContext : DbContext
  {
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {

    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<User>().ToTable("User");
      modelBuilder.Entity<User>()
        .Property(u => u.Role)
        .HasConversion<string>();

      // Load data.
      modelBuilder.Entity<User>().HasData(
        new User { Id = 1234, Username = "AronKwats", Name = "Aron Heesakkers", Email = "aron@email.com", Password = "asdf", Role = Role.ADMIN },
        new User { Id = 12345, Username = "AronKwats", Name = "Aron Heesakkers", Email = "aron@email.com", Password = "asdf", Role = Role.ADMIN });
    }
  }
}