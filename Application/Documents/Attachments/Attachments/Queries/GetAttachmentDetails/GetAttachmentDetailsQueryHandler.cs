using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Models.Documents.Attachments;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Documents.Attachments.Attachments.Queries.GetAttachmentDetails
{
    public class GetAttachmentDetailsQueryHandler : IRequestHandler<GetAttachmentDetailsQuery, AttachmentDetailsVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetAttachmentDetailsQueryHandler(IDbContext context, IMapper mapper) => (_context,_mapper) = (context, mapper);

        public async Task<AttachmentDetailsVm> Handle(GetAttachmentDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Attachments.FirstOrDefaultAsync(attachment => attachment.Id == request.Id, cancellationToken);
            if(entity == null)
            {
                throw new NotFoundException(nameof(Attachment), request.Id);
            }
            return _mapper.Map<AttachmentDetailsVm>(entity);
        }
    }
}
