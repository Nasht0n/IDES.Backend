using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Models.Documents.Requisites;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Requisites.DateRequisites.Queries.GetDateRequisiteDetails
{
    public class GetDateRequisiteQueryHandler:IRequestHandler<GetDateRequisiteQuery,DateRequisiteVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetDateRequisiteQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DateRequisiteVm> Handle(GetDateRequisiteQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _context.DateRequisites.FirstOrDefaultAsync(dr => dr.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(DateRequisite), request.Id);
            }

            return _mapper.Map<DateRequisiteVm>(entity);
        }
    }
}
