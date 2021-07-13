using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Models.OrganizationStructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.OrganizationStructure.Departments.Queries.GetDepartmentDetails
{
    public class GetDepartmentDetailsQueryHandler:IRequestHandler<GetDepartmentDetailsQuery, DepartmentDetailsVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetDepartmentDetailsQueryHandler(IDbContext context, IMapper mapper)=>(_context,_mapper) = (context, mapper);

        public async Task<DepartmentDetailsVm> Handle(GetDepartmentDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _context.Departments.FirstOrDefaultAsync(department => department.Id == request.Id,
                    cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Department), request.Id);
            }

            return _mapper.Map<DepartmentDetailsVm>(entity);
        }
    }
}
