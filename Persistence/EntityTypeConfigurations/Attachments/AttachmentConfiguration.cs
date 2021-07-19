using Domain.Models.Documents.Attachments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations.Attachments
{
    public class AttachmentConfiguration:IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.HasKey(a => a.Id);
            builder.HasIndex(a => a.Id).IsUnique();

            builder.Property(a => a.Filename).HasMaxLength(255).IsRequired();
            builder.Property(a => a.Extension).HasMaxLength(255).IsRequired();
            builder.Property(a => a.FileContent).IsRequired();

            builder.Property(a => a.IsDeleted).IsRequired();
        }
    }
}
