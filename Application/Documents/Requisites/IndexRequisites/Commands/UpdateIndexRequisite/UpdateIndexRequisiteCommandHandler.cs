using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models.Documents.Requisites;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Requisites.IndexRequisites.Commands.UpdateIndexRequisite
{
    public class UpdateIndexRequisiteCommandHandler:IRequestHandler<UpdateIndexRequisiteCommand>
    {
        private readonly IDbContext _context;

        public UpdateIndexRequisiteCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(UpdateIndexRequisiteCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _context.IndexRequisites.FirstOrDefaultAsync(ir => ir.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(IndexRequisite), request.Id);
            }

            entity.Value = request.Value;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
