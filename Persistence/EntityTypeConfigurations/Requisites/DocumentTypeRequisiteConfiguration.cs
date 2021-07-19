using Domain.Models.Documents.Requisites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations.Requisites
{
    public class DocumentTypeRequisiteConfiguration:IEntityTypeConfiguration<DocumentTypeRequisite>
    {
        public void Configure(EntityTypeBuilder<DocumentTypeRequisite> builder)
        {
            builder.HasKey(dtr => dtr.Id);
            builder.HasIndex(dtr => dtr.Id).IsUnique();

            builder.Property(dtr => dtr.Value).IsRequired().HasMaxLength(255);

            builder.Property(dtr => dtr.IsDeleted).IsRequired();
        }
    }
}
