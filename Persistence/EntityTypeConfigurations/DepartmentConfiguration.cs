using Domain.Models.OrganizationStructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations
{
    public class DepartmentConfiguration:IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(department => department.Id);
            builder.HasIndex(department => department.Id).IsUnique();
            builder.Property(department => department.Name).HasMaxLength(250);
            builder.Property(department => department.IsDeleted).IsRequired();
        }
    }
}
