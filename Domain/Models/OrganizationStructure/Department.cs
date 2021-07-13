using System.Collections.Generic;

namespace Domain.Models.OrganizationStructure
{
    public class Department:BaseObject
    {
        public string Name { get; set; }

        public IList<Employee> Employees { get; set; }
    }
}
