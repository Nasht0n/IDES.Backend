using Domain.Models.Documents.Requisites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations.Requisites
{
    public class TitleRequisiteConfiguration:IEntityTypeConfiguration<TitleRequisite>
    {
        public void Configure(EntityTypeBuilder<TitleRequisite> builder)
        {
            builder.HasKey(tr => tr.Id);
            builder.HasIndex(tr => tr.Id).IsUnique();

            builder.Property(tr => tr.Value).IsRequired();

            builder.Property(tr => tr.IsDeleted).IsRequired();
        }
    }
}
