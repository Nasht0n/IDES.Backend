using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models.Documents.Requisites;
using MediatR;

namespace Application.Documents.Requisites.DateRequisites.Commands.CreateDateRequisite
{
    public class CreateDateRequisiteCommandHandler:IRequestHandler<CreateDateRequisiteCommand,Guid>
    {
        private readonly IDbContext _context;

        public CreateDateRequisiteCommandHandler(IDbContext context) => _context = context;

        public async Task<Guid> Handle(CreateDateRequisiteCommand request, CancellationToken cancellationToken)
        {
            DateRequisite requisite = new() { IsDeleted = false, Value = request.Date };

            await _context.DateRequisites.AddAsync(requisite, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return requisite.Id;
        }
    }
}
