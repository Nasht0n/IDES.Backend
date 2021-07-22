using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models.Documents.Requisites;
using MediatR;

namespace Application.Documents.Requisites.TitleRequisites.Commands.DeleteTitleRequisite
{
    public class DeleteTitleRequisiteCommandHandler:IRequestHandler<DeleteTitleRequisiteCommand>
    {
        private readonly IDbContext _context;

        public DeleteTitleRequisiteCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(DeleteTitleRequisiteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.TitleRequisites.FindAsync(new object[] {request.Id}, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(TitleRequisite), request.Id);
            }

            entity.IsDeleted = true;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
