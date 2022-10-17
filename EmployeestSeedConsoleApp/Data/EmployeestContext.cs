using EmployeestSeedConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmployeestSeedConsoleApp.Data
{
    public class EmployeestContext : DbContext
    {
        private string connectionString;

        public EmployeestContext(IConfigurationRoot configuration)
        {
            connectionString = configuration["ConnectionStrings:connectionString"];
        }

        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>().HasData(
                new Permission
                {
                    Id = 1,
                    Name = "Test name"
                });
        }
    }
}
