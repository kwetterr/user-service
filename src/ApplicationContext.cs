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
            modelBuilder.Entity<User>().HasData(
              new { Id = 1, FirstName="Aron", LastName = "Andriy", Username = "AronH", Password="asdf" },
              new { Id = 2, FirstName="Aron2", LastName = "Andriy2", Username = "AronH2", Password="asdf2" });
        }
    }
}