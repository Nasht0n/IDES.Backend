using Domain.Models.Documents.Casts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations.Casts
{
    public class OrderApproverConfiguration:IEntityTypeConfiguration<OrderApprover>
    {
        public void Configure(EntityTypeBuilder<OrderApprover> builder)
        {
            builder.HasKey(oa => new { oa.EmployeeId, oa.DocumentId });

            builder.HasOne(od => od.OrderDocument)
                .WithMany(a => a.Approvers)
                .HasForeignKey(oa => oa.DocumentId);

            builder.HasOne(oa => oa.Employee)
                .WithMany(a => a.Approvers)
                .HasForeignKey(oa => oa.EmployeeId);

            builder.Property(oa => oa.Rank).IsRequired();
        }
    }
}
