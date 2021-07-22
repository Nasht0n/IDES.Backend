using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using Domain.Models.Documents.Requisites;
using MediatR;

namespace Application.Documents.Requisites.IndexRequisites.Commands.DeleteIndexRequisite
{
    public class DeleteIndexRequisiteCommandHandler:IRequestHandler<DeleteIndexRequisiteCommand>
    {
        private readonly IDbContext _context;

        public DeleteIndexRequisiteCommandHandler(IDbContext context) => _context = context;

        public async Task<Unit> Handle(DeleteIndexRequisiteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.IndexRequisites.FindAsync(new object[] {request.Id}, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(IndexRequisite), request.Id);
            }

            entity.IsDeleted = true;
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
