using Application.Interfaces;
using Domain.Models.Identity;
using Domain.Models.OrganizationStructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityTypeConfigurations;

namespace Persistence
{
    public class IdesDbContext: IdentityDbContext<AppUser>, IDbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public IdesDbContext(DbContextOptions<IdesDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}