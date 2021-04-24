using AutoMapper;
using eHairdresserSalonFare.Model.Requests.Sponsor;
using eHairdresserSalonFareBugojno.Database;
using eHairdresserSalonFareBugojno.DBContext;
using System.Collections.Generic;
using System.Linq;

namespace eHairdresserSalonFare.Api.Repository
{
    public class SponsorRepository : BaseCRUDRepository<Model.Sponsor, SponsorSearchRequest, Sponsor, SponsorUpsertRequest, SponsorUpsertRequest>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public SponsorRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override IEnumerable<Model.Sponsor> Get(SponsorSearchRequest request)
        {
            var query = _context.Sponsors.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.SponsorName))
            {
                query = query.Where(x => x.SponsorName.Contains(request.SponsorName));
            }

            if (!string.IsNullOrWhiteSpace(request?.Phone))
            {
                query = query.Where(x => x.Phone.Contains(request.Phone));
            }

            if (!string.IsNullOrWhiteSpace(request?.Email))
            {
                query = query.Where(x => x.Email.Contains(request.Email));
            }

            return _mapper.Map<IEnumerable<Model.Sponsor>>(query.ToList());
        }
    }
}
