using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Models.Documents.Requisites;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Requisites.IndexRequisites.Queries.GetIndexRequisiteDetails
{
    public class GetIndexRequisiteDetailsQueryHandler:IRequestHandler<GetIndexRequisiteDetailsQuery,IndexRequisiteVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetIndexRequisiteDetailsQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IndexRequisiteVm> Handle(GetIndexRequisiteDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.IndexRequisites.FirstOrDefaultAsync(ir => ir.Id == request.Id,cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(IndexRequisite), request.Id);
            }

            return _mapper.Map<IndexRequisiteVm>(entity);
        }
    }
}
