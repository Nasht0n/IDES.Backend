using System;
using System.Collections.Generic;
using Domain.Models.Documents.Casts;
using Domain.Models.Identity;

namespace Domain.Models.OrganizationStructure
{
    public class Employee:BaseObject
    {
        public Guid DepartmentId { get; set; }

        public string Fullname { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        
        public Department Department { get; set; }
        public ICollection<AppUser> Users { get; set; }

        public IList<OrderCreator> Creators { get; set; }
        public IList<OrderApprover> Approvers { get; set; }
    }
}
