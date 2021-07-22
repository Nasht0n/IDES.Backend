using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using Domain.Models.Documents.Requisites;
using MediatR;

namespace Application.Documents.Requisites.TitleRequisites.Commands.CreateTitleRequisite
{
    public class CreateTitleRequisiteCommandHandler:IRequestHandler<CreateTitleRequisiteCommand,Guid>
    {
        private readonly IDbContext _context;

        public CreateTitleRequisiteCommandHandler(IDbContext context) => _context = context;

        public async Task<Guid> Handle(CreateTitleRequisiteCommand request, CancellationToken cancellationToken)
        {
            TitleRequisite requisite = new() { Id = Guid.NewGuid(), Value = request.Value, IsDeleted = false};
            await _context.TitleRequisites.AddAsync(requisite, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return requisite.Id;
        }
    }
}
