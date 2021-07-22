using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Requisites.TitleRequisites.Queries.GetTitleRequisiteList
{
    public class GetTitleRequisiteListQueryHandler : IRequestHandler<GetTitleRequisiteListQuery, TitleRequisiteListVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetTitleRequisiteListQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<TitleRequisiteListVm> Handle(GetTitleRequisiteListQuery request, CancellationToken cancellationToken)
        {
            var requisites = await _context.TitleRequisites.Where(tr => tr.IsDeleted == request.IsDelete)
                .ProjectTo<TitleRequisiteLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new TitleRequisiteListVm() {Requisites = requisites};
        }
    }
}

