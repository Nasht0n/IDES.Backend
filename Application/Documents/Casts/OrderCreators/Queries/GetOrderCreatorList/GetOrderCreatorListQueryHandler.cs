using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Casts.OrderCreators.Queries.GetOrderCreatorList
{
    public class GetOrderCreatorListQueryHandler:IRequestHandler<GetOrderCreatorListQuery,OrderCreatorListVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderCreatorListQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderCreatorListVm> Handle(GetOrderCreatorListQuery request, CancellationToken cancellationToken)
        {
            var creators = await _context.OrderCreators
                .Where(oc => oc.DocumentId == request.OrderDocumentId)
                .ProjectTo<OrderCreatorLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new OrderCreatorListVm() {Creators = creators};
        }
    }
}
