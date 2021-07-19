using Domain.Models.Documents.Attachments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations.Attachments
{
    public class OrderAttachmentConfiguration:IEntityTypeConfiguration<OrderAttachment>
    {
        public void Configure(EntityTypeBuilder<OrderAttachment> builder)
        {
            builder.HasKey(oa => new {oa.AttachmentId, oa.OrderDocumentId});

            builder.HasOne(od => od.OrderDocument)
                .WithMany(a => a.OrderAttachments)
                .HasForeignKey(oa => oa.OrderDocumentId);

            builder.HasOne(oa => oa.Attachment)
                .WithMany(a => a.OrderAttachments)
                .HasForeignKey(oa => oa.AttachmentId);
        }
    }
}
