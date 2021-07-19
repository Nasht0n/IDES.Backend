using Domain.Models.Documents.Requisites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations.Requisites
{
    public class DateRequisiteConfiguration:IEntityTypeConfiguration<DateRequisite>
    {
        public void Configure(EntityTypeBuilder<DateRequisite> builder)
        {
            builder.HasKey(dr => dr.Id);
            builder.HasIndex(dr => dr.Id).IsUnique();

            builder.Property(dr => dr.IsDeleted).IsRequired();
            builder.Property(dr => dr.Value).IsRequired();
        }
    }
}
