using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models.Documents.Requisites;
using MediatR;

namespace Application.Documents.Requisites.DocumentTypeRequisites.Commands.UpdateDocumentTypeRequisite
{
    public class UpdateDocumentTypeRequisiteCommandHandler:IRequestHandler<UpdateDocumentTypeRequisiteCommand>
    {
        private readonly IDbContext _context;

        public UpdateDocumentTypeRequisiteCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(UpdateDocumentTypeRequisiteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.DocumentTypeRequisites.FindAsync(new object[] {request.Id}, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(DocumentTypeRequisite), request.Id);
            }

            entity.Value = request.Value;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
