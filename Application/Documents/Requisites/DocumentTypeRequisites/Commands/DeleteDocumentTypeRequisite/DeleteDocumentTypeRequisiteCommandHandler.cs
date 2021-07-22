using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models.Documents.Requisites;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Requisites.DocumentTypeRequisites.Commands.DeleteDocumentTypeRequisite
{
    public class DeleteDocumentTypeRequisiteCommandHandler:IRequestHandler<DeleteDocumentTypeRequisiteCommand>
    {
        private readonly IDbContext _context;

        public DeleteDocumentTypeRequisiteCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(DeleteDocumentTypeRequisiteCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _context.DocumentTypeRequisites.FirstOrDefaultAsync(req => req.Id == request.Id,
                    cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(DocumentTypeRequisite), request.Id);
            }

            entity.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
