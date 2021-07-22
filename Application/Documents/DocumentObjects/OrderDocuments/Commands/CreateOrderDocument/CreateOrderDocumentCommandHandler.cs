using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models.Documents.DocumentObjects;
using MediatR;

namespace Application.Documents.DocumentObjects.OrderDocuments.Commands.CreateOrderDocument
{
    public class CreateOrderDocumentCommandHandler:IRequestHandler<CreateOrderDocumentCommand, Guid>
    {
        private readonly IDbContext _context;

        public CreateOrderDocumentCommandHandler(IDbContext context) => _context = context;

        public async Task<Guid> Handle(CreateOrderDocumentCommand request, CancellationToken cancellationToken)
        {
            OrderDocument document = new()
            {
                Id = Guid.NewGuid(),
                IsDeleted = false,

                TypeId = request.TypeId,
                TitleId = request.TitleId,
                State = request.State,

                IndexId = request.IndexId,
                DateTimeId = request.DateTimeId
            };

            await _context.OrderDocuments.AddAsync(document, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return document.Id;
        }
    }
}
