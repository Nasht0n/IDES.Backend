using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Documents.Attachments.Attachments.Queries.GetAttachmentList
{
    public class GetAttachmentListQueryHandler : IRequestHandler<GetAttachmentListQuery, AttachmentListVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetAttachmentListQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AttachmentListVm> Handle(GetAttachmentListQuery request, CancellationToken cancellationToken)
        {
            var attachments = await _context.Attachments
                .Where(attachment => attachment.IsDeleted == request.IsDeleted)
                .ProjectTo<AttachmentLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new AttachmentListVm { Attachments = attachments };
        }
    }
}
