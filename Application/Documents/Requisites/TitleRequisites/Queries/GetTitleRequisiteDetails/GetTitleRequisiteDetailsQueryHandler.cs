using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain.Models.Documents.Requisites;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Requisites.TitleRequisites.Queries.GetTitleRequisiteDetails
{
    public class GetTitleRequisiteDetailsQueryHandler:IRequestHandler<GetTitleRequisiteDetailsQuery,TitleRequisiteDetailsVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetTitleRequisiteDetailsQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TitleRequisiteDetailsVm> Handle(GetTitleRequisiteDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _context.TitleRequisites.FirstOrDefaultAsync(tr => tr.Id == request.Id, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(TitleRequisite), request.Id);
            }

            return _mapper.Map<TitleRequisiteDetailsVm>(entity);
        }
    }
}
