using Application.Interfaces;
using Domain.Models.Documents.Attachments;
using Domain.Models.Documents.Casts;
using Domain.Models.Documents.DocumentObjects;
using Domain.Models.Documents.Requisites;
using Domain.Models.Identity;
using Domain.Models.OrganizationStructure;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityTypeConfigurations.Attachments;
using Persistence.EntityTypeConfigurations.Casts;
using Persistence.EntityTypeConfigurations.DocumentObjects;
using Persistence.EntityTypeConfigurations.Identities;
using Persistence.EntityTypeConfigurations.OrganizationStructures;
using Persistence.EntityTypeConfigurations.Requisites;

namespace Persistence
{
    public class IdesDbContext: IdentityDbContext<AppUser>, IDbContext
    {
        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<OrderAttachment> OrderAttachments { get; set; }
        public DbSet<OrderApprover> OrderApprovers { get; set; }
        public DbSet<OrderCreator> OrderCreators { get; set; }
        public DbSet<OrderDocument> OrderDocuments { get; set; }
        public DbSet<DateRequisite> DateRequisites { get; set; }
        public DbSet<DocumentTypeRequisite> DocumentTypeRequisites { get; set; }
        public DbSet<IndexRequisite> IndexRequisites { get; set; }
        public DbSet<TitleRequisite> TitleRequisites { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public IdesDbContext(DbContextOptions<IdesDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // attachments
            modelBuilder.ApplyConfiguration(new AttachmentConfiguration());
            modelBuilder.ApplyConfiguration(new OrderAttachmentConfiguration());
            // casts
            modelBuilder.ApplyConfiguration(new OrderApproverConfiguration());
            modelBuilder.ApplyConfiguration(new OrderCreatorConfiguration());
            // document objects
            modelBuilder.ApplyConfiguration(new OrderDocumentConfiguration());
            // identities
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
            // organization structure
            modelBuilder.ApplyConfiguration(new DepartmentConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            // requisites
            modelBuilder.ApplyConfiguration(new DateRequisiteConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentTypeRequisiteConfiguration());
            modelBuilder.ApplyConfiguration(new IndexRequisiteConfiguration());
            modelBuilder.ApplyConfiguration(new TitleRequisiteConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}