using Domain.Models.OrganizationStructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations.OrganizationStructures
{
    public class EmployeeConfiguration:IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(employee => employee.Id);
            builder.HasIndex(employee => employee.Id).IsUnique();
            builder.Property(employee => employee.Fullname).IsRequired().HasMaxLength(250);
            builder.Property(employee => employee.Position).IsRequired().HasMaxLength(250);
            builder.Property(employee => employee.Email).HasMaxLength(250);
            builder.Property(employee => employee.IsDeleted).IsRequired();

            builder.HasOne(employee => employee.Department)
                .WithMany(department => department.Employees)
                .HasForeignKey(employee=>employee.DepartmentId);
        }
    }
}
