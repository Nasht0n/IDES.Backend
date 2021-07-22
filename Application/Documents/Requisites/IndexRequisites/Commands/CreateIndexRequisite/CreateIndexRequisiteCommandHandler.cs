using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models.Documents.Requisites;
using MediatR;

namespace Application.Documents.Requisites.IndexRequisites.Commands.CreateIndexRequisite
{
    public class CreateIndexRequisiteCommandHandler:IRequestHandler<CreateIndexRequisiteCommand,Guid>
    {
        private readonly IDbContext _context;

        public CreateIndexRequisiteCommandHandler(IDbContext context) => _context = context;

        public async Task<Guid> Handle(CreateIndexRequisiteCommand request, CancellationToken cancellationToken)
        {
            IndexRequisite requisite = new()
            {
                Id = Guid.NewGuid(),
                IsDeleted = false,
                Value = request.Value
            };

            await _context.IndexRequisites.AddAsync(requisite, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return requisite.Id;
        }
    }
}
