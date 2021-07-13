using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.OrganizationStructure.Departments.Queries.GetDepartmentList
{
    public class GetDepartmentListQueryHandler:IRequestHandler<GetDepartmentListQuery, DepartmentListVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetDepartmentListQueryHandler(IDbContext context, IMapper mapper) =>
            (_context, _mapper) = (context, mapper);


        public async Task<DepartmentListVm> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
        {
            var departmentsQuery = await _context.Departments
                .Where(department => department.IsDeleted == request.IsDeleted)
                .ProjectTo<DepartmentLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new DepartmentListVm {Departments = departmentsQuery};
        }
    }
}
