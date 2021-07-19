using Domain.Models.Documents.Requisites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations.Requisites
{
    public class IndexRequisiteConfiguration:IEntityTypeConfiguration<IndexRequisite>
    {
        public void Configure(EntityTypeBuilder<IndexRequisite> builder)
        {
            builder.HasKey(ir => ir.Id);
            builder.HasIndex(ir => ir.Id).IsUnique();

            builder.Property(ir => ir.Value).IsRequired();

            builder.Property(ir => ir.IsDeleted).IsRequired();
        }
    }
}
