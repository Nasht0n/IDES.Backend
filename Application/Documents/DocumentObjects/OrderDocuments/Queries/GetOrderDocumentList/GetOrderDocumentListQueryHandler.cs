using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.DocumentObjects.OrderDocuments.Queries.GetOrderDocumentList
{
    public class GetOrderDocumentListQueryHandler:IRequestHandler<GetOrderDocumentListQuery,OrderDocumentListVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderDocumentListQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderDocumentListVm> Handle(GetOrderDocumentListQuery request, CancellationToken cancellationToken)
        {
            var documents = await _context.OrderDocuments
                .ProjectTo<OrderDocumentLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);


            if (!request.IsDeleted)
            {
                documents = documents.Where(doc => doc.IsDeleted == request.IsDeleted).ToList();
            }

            return new OrderDocumentListVm() {Documents = documents};
        }
    }
}
