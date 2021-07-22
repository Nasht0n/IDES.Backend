using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Documents.Requisites.DateRequisites.Queries.GetDateRequisiteList
{
    public class GetDateRequisiteListQueryHandler:IRequestHandler<GetDateRequisiteListQuery,DateRequisiteListVm>
    {
        private readonly IDbContext _context;
        private readonly IMapper _mapper;

        public GetDateRequisiteListQueryHandler(IDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DateRequisiteListVm> Handle(GetDateRequisiteListQuery request, CancellationToken cancellationToken)
        {
            var requisites = await _context.DateRequisites.Where(dr => dr.IsDeleted == request.IsDeleted)
                .ProjectTo<DateRequisiteLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return new DateRequisiteListVm() {Requisites = requisites};
        }
    }
}
