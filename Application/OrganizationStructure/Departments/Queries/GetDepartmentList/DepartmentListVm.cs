using System.Collections.Generic;

namespace Application.OrganizationStructure.Departments.Queries.GetDepartmentList
{
    public class DepartmentListVm
    {
        public IList<DepartmentLookupDto> Departments { get; set; }
    }
}
