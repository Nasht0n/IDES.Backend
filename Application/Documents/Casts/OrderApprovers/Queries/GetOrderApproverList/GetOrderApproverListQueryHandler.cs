using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Casts.OrderApprovers.Queries.GetOrderApproverList
{
    public class GetOrderApproverListQueryHandler:IRequestHandler<GetOrderApproverListQuery,OrderApproverListVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderApproverListQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderApproverListVm> Handle(GetOrderApproverListQuery request, CancellationToken cancellationToken)
        {
            var approvers = await _context.OrderApprovers.Where(oa => oa.DocumentId == request.OrderDocumentId)
                .ProjectTo<OrderApproverLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new OrderApproverListVm() {Approvers = approvers};
        }
    }
}
