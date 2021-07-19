using Domain.Models.Documents.Casts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations.Casts
{
    public class OrderCreatorConfiguration:IEntityTypeConfiguration<OrderCreator>
    {
        public void Configure(EntityTypeBuilder<OrderCreator> builder)
        {
            builder.HasKey(oa => new { oa.EmployeeId, oa.DocumentId });

            builder.HasOne(od => od.Employee)
                .WithMany(a => a.Creators)
                .HasForeignKey(oa => oa.EmployeeId);

            builder.HasOne(oa => oa.OrderDocument)
                .WithMany(a => a.Creators)
                .HasForeignKey(oa => oa.DocumentId);
        }
    }
}
