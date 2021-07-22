using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Models.Documents.DocumentObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.DocumentObjects.OrderDocuments.Queries.GetOrderDocumentDetails
{
    public class GetOrderDocumentDetailsQueryHandler:IRequestHandler<GetOrderDocumentDetailsQuery,OrderDocumentVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderDocumentDetailsQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDocumentVm> Handle(GetOrderDocumentDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _context.OrderDocuments.FirstOrDefaultAsync(od => od.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(OrderDocument), request.Id);
            }

            return _mapper.Map<OrderDocumentVm>(entity);
        }
    }
}
