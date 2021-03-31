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
              new User { Id = "feabb8fb-6d8c-48a4-b060-e02c66b25405", Username = "AronKwats", Name = "Aron Heesakkers", Email = "aron@email.com", Password = "asdf", Country = "NL", Role = Role.ADMIN, Biography = "Zit hier voor de fun, voor de gezelligheid, voor de humor, beetje slap ouwehoeren, als ik gemekker wil koop ik wel een geit.", Avatar = "https://cdn.pixabay.com/photo/2018/08/28/12/41/avatar-3637425_1280.png" },
              new User { Id = "c30fa353-d4e2-4b72-bbcf-0cd963763316", Username = "Jaapie98", Name = "Jaap van der Meer", Email = "jaap@email.com", Password = "asdf", Country = "NL", Role = Role.MODERATOR },
              new User { Id = "25853618-ef7b-44e8-aec2-bc7dae97498b", Username = "SverrieBoy", Name = "Sverre van Gompel", Email = "sverre@email.com", Password = "asdf", Country = "NL", Role = Role.USER },
              new User { Id = "61e1b100-6626-4aa0-b15b-53a1fe5503ec", Username = "Timothy", Name = "Tim la Haije", Email = "tim@email.com", Password = "asdf", Country = "NL", Role = Role.USER },
              new User { Id = "5685180c-a18e-4fc9-9d79-985f85b8fc1d", Username = "Dirkvdw", Name = "Dirk van de Waerden", Email = "dirk@email.com", Password = "asdf", Country = "NL", Role = Role.USER }
            );
        }
    }
}