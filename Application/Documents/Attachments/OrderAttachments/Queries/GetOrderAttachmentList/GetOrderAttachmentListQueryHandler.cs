using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Attachments.OrderAttachments.Queries.GetOrderAttachmentList
{
    public class GetOrderAttachmentListQueryHandler:IRequestHandler<GetOrderAttachmentListQuery,OrderAttachmentListVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderAttachmentListQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OrderAttachmentListVm> Handle(GetOrderAttachmentListQuery request, CancellationToken cancellationToken)
        {
            var attachments = await _context.OrderAttachments
                .Where(oa => oa.OrderDocumentId == request.OrderDocumentId)
                .ProjectTo<OrderAttachmentLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new OrderAttachmentListVm() {OrderAttachments = attachments};
        }
    }
}
