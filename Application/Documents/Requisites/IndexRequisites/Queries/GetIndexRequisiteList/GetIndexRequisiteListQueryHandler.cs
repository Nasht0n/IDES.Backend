using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Requisites.IndexRequisites.Queries.GetIndexRequisiteList
{
    public class GetIndexRequisiteListQueryHandler:IRequestHandler<GetIndexRequisiteListQuery,IndexRequisiteListVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetIndexRequisiteListQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IndexRequisiteListVm> Handle(GetIndexRequisiteListQuery request, CancellationToken cancellationToken)
        {
            var requisites = await _context.IndexRequisites.Where(ir => ir.IsDeleted == request.IsDeleted)
                .ProjectTo<IndexRequisiteLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new IndexRequisiteListVm() {Requisites = requisites};
        }
    }
}
