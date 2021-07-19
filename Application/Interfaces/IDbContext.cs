using System.Threading;
using System.Threading.Tasks;
using Domain.Models.Documents.Attachments;
using Domain.Models.Documents.Casts;
using Domain.Models.Documents.DocumentObjects;
using Domain.Models.Documents.Requisites;
using Domain.Models.OrganizationStructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IDbContext
    {
        DbSet<Attachment> Attachments { get; set; }
        DbSet<OrderAttachment> OrderAttachments { get; set; }

        DbSet<OrderApprover> OrderApprovers { get; set; }
        DbSet<OrderCreator> OrderCreators { get; set; }

        DbSet<OrderDocument> OrderDocuments { get; set; }

        DbSet<DateRequisite> DateRequisites { get; set; }
        DbSet<DocumentTypeRequisite> DocumentTypeRequisites { get; set; }
        DbSet<IndexRequisite> IndexRequisites { get; set; }
        DbSet<TitleRequisite> TitleRequisites { get; set; }

        DbSet<Department> Departments { get; set; }
        DbSet<Employee> Employees { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}