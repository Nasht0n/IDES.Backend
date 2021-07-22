using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models.Documents.Requisites;
using MediatR;

namespace Application.Documents.Requisites.DateRequisites.Commands.DeleteDateRequisite
{
    public class DeleteDateRequisiteCommandHandler:IRequestHandler<DeleteDateRequisiteCommand>
    {
        private readonly IDbContext _context;

        public DeleteDateRequisiteCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(DeleteDateRequisiteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.DateRequisites.FindAsync(new object[] {request.Id}, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(DateRequisite), request.Id);
            }

            entity.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
