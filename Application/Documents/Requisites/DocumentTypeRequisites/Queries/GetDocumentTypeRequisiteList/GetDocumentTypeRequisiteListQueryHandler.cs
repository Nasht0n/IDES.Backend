using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Requisites.DocumentTypeRequisites.Queries.GetDocumentTypeRequisiteList
{
    public class GetDocumentTypeRequisiteListQueryHandler:IRequestHandler<GetDocumentTypeRequisiteListQuery,DocumentTypeRequisiteListVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetDocumentTypeRequisiteListQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DocumentTypeRequisiteListVm> Handle(GetDocumentTypeRequisiteListQuery request, CancellationToken cancellationToken)
        {
            var requisites = await _context.DocumentTypeRequisites.Where(req => req.IsDeleted == request.IsDeleted)
                .ProjectTo<DocumentTypeRequisiteLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new DocumentTypeRequisiteListVm() {Requisites = requisites};
        }
    }
}
