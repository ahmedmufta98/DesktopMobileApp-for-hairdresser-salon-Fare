using AutoMapper;
using eHairdresserSalonFare.Model.Requests.Associate;
using eHairdresserSalonFareBugojno.Database;
using eHairdresserSalonFareBugojno.DBContext;
using System.Collections.Generic;
using System.Linq;

namespace eHairdresserSalonFare.Api.Repository
{
    public class AssociateRepository : BaseCRUDRepository<Model.Associate, AssociateSearchRequest, Associate, AssociateUpsertRequest, AssociateUpsertRequest>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AssociateRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override IEnumerable<Model.Associate> Get(AssociateSearchRequest request)
        {
            var query = _context.Associates.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.AssociateName))
            {
                query = query.Where(x => x.AssociateName.Contains(request.AssociateName));
            }

            if (!string.IsNullOrWhiteSpace(request?.Phone))
            {
                query = query.Where(x => x.Phone.Contains(request.Phone));
            }

            if (!string.IsNullOrWhiteSpace(request?.Email))
            {
                query = query.Where(x => x.Email.Contains(request.Email));
            }

            return _mapper.Map<IEnumerable<Model.Associate>>(query.ToList());
        }
    }
}
