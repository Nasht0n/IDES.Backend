using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models.Documents.Requisites;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Requisites.DateRequisites.Commands.UpdateDateRequisite
{
    public class UpdateDateRequisiteCommandHandler:IRequestHandler<UpdateDateRequisiteCommand>
    {
        private readonly IDbContext _context;

        public UpdateDateRequisiteCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(UpdateDateRequisiteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.DateRequisites.FirstOrDefaultAsync(d => d.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(DateRequisite), request.Id);
            }

            entity.Value = request.Date;

            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
