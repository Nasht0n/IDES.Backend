using System;
using Domain.Models.OrganizationStructure;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models.Identity
{
    public class AppUser : IdentityUser
    {
        public Guid EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
