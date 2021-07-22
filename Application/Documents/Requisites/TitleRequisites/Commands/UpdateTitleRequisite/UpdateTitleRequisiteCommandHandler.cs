using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models.Documents.Requisites;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Requisites.TitleRequisites.Commands.UpdateTitleRequisite
{
    public class UpdateTitleRequisiteCommandHandler:IRequestHandler<UpdateTitleRequisiteCommand>
    {
        private readonly IDbContext _context;

        public UpdateTitleRequisiteCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(UpdateTitleRequisiteCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _context.TitleRequisites.FirstOrDefaultAsync(tr => tr.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TitleRequisite), request.Id);
            }

            entity.Value = request.Value;
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
