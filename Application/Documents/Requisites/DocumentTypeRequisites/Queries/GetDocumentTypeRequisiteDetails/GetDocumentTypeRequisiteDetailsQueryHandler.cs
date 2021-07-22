using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Models.Documents.Requisites;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Requisites.DocumentTypeRequisites.Queries.GetDocumentTypeRequisiteDetails
{
    public class GetDocumentTypeRequisiteDetailsQueryHandler:IRequestHandler<GetDocumentTypeRequisiteDetailsQuery, DocumentTypeRequisiteVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetDocumentTypeRequisiteDetailsQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DocumentTypeRequisiteVm> Handle(GetDocumentTypeRequisiteDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _context.DocumentTypeRequisites.FirstOrDefaultAsync(req => req.Id == request.Id,
                    cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(DocumentTypeRequisite), request.Id);
            }

            return _mapper.Map<DocumentTypeRequisiteVm>(entity);
        }
    }
}
