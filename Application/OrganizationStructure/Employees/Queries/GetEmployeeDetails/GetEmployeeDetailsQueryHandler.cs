using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Models.OrganizationStructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.OrganizationStructure.Employees.Queries.GetEmployeeDetails
{
    public class GetEmployeeDetailsQueryHandler:IRequestHandler<GetEmployeeDetailsQuery, EmployeeDetailsVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetEmployeeDetailsQueryHandler(IDbContext context, IMapper mapper) =>
            (_context, _mapper) = (context, mapper);

        public async Task<EmployeeDetailsVm> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
        {

            var entity =
                await _context.Employees.FirstOrDefaultAsync(employee => employee.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            return _mapper.Map<EmployeeDetailsVm>(entity);
        }
    }
}
