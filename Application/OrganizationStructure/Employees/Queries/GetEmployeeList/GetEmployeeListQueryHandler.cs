using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.OrganizationStructure.Employees.Queries.GetEmployeeList
{
    public class GetEmployeeListQueryHandler:IRequestHandler<GetEmployeeListQuery,EmployeeListVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetEmployeeListQueryHandler(IDbContext context, IMapper mapper) =>
            (_context, _mapper) = (context, mapper);

        public async Task<EmployeeListVm> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
        {
            var employeesQuery = await _context.Employees
                .Where(employee => employee.IsDeleted == request.IsDeleted)
                .ProjectTo<EmployeeLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new EmployeeListVm() { Employees = employeesQuery };
        }
    }
}
