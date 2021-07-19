using System;
using Domain.Models.Documents.DocumentObjects;
using Domain.Models.OrganizationStructure;

namespace Domain.Models.Documents.Casts
{
    public class OrderApprover
    {
        public Guid DocumentId { get; set; }
        public Guid EmployeeId { get; set; }
        public int Rank { get; set; }

        public OrderDocument OrderDocument { get; set; }
        public Employee Employee { get; set; }
    }
}
