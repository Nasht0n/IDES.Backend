using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models.Documents.Requisites;
using MediatR;

namespace Application.Documents.Requisites.DocumentTypeRequisites.Commands.CreateDocumentTypeRequisite
{
    public class CreateDocumentTypeRequisiteCommandHandler:IRequestHandler<CreateDocumentTypeRequisiteCommand, Guid>
    {
        private readonly IDbContext _context;

        public CreateDocumentTypeRequisiteCommandHandler(IDbContext context) => _context = context;

        public async Task<Guid> Handle(CreateDocumentTypeRequisiteCommand request, CancellationToken cancellationToken)
        {
            DocumentTypeRequisite requisite = new()
            {
                Id = Guid.NewGuid(),
                IsDeleted = false,
                Value = request.Value
            };

            await _context.DocumentTypeRequisites.AddAsync(requisite, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return requisite.Id;
        }
    }
}
