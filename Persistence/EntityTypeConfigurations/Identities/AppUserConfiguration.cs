using Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations.Identities
{
    public class AppUserConfiguration:IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasOne(u => u.Employee)
                .WithMany(e => e.Users)
                .HasForeignKey(u => u.EmployeeId);
        }
    }
}
