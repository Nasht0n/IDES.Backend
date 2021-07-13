using System.Collections.Generic;

namespace Application.OrganizationStructure.Employees.Queries.GetEmployeeList
{
    public class EmployeeListVm
    {
        public IList<EmployeeLookupDto> Employees { get; set; }
    }
}
