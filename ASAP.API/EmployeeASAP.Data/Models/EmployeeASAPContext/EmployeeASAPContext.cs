
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace EmployeeASAP.Data.Models
{
    public class EmployeeASAPContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Address> Address { get; set; }

        public EmployeeASAPContext()
        {
        }
        public EmployeeASAPContext(DbContextOptions<EmployeeASAPContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Address>().ToTable("Addresses");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }
    }
}
