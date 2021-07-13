using System;

namespace Domain.Models.OrganizationStructure
{
    public class Employee:BaseObject
    {
        public Guid DepartmentId { get; set; }

        public string Fullname { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }

        public Department Department { get; set; }
    }
}
