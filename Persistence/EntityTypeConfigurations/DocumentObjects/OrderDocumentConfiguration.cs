using Domain.Models.Documents.DocumentObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations.DocumentObjects
{
    public class OrderDocumentConfiguration:IEntityTypeConfiguration<OrderDocument>
    {
        public void Configure(EntityTypeBuilder<OrderDocument> builder)
        {
            builder.HasKey(od => od.Id);
            builder.HasIndex(od => od.Id).IsUnique();
            
            builder.Property(od => od.IsDeleted).IsRequired();

            builder.HasOne(od => od.DocumentType)
                .WithMany(dt => dt.OrderDocuments)
                .HasForeignKey(od => od.TypeId);

            builder.HasOne(od => od.Title)
                .WithMany(t => t.OrderDocuments)
                .HasForeignKey(od => od.TitleId);

            builder.Property(od => od.State).IsRequired();

            builder.HasOne(od => od.Index)
                .WithMany(i => i.OrderDocuments)
                .HasForeignKey(od => od.IndexId)
                .IsRequired(false);

            builder.HasOne(od => od.Date)
                .WithMany(d => d.OrderDocuments)
                .HasForeignKey(od => od.DateTimeId)
                .IsRequired(false);
        }
    }
}
