using AutoMapper;
using eHairdresserSalonFare.Model.Requests.Hairdresser;
using eHairdresserSalonFareBugojno.Database;
using eHairdresserSalonFareBugojno.DBContext;
using System.Collections.Generic;
using System.Linq;

namespace eHairdresserSalonFare.Api.Repository
{
    public class HairdresserRepository : BaseCRUDRepository<Model.Hairdresser, HairdresserSearchRequest, Hairdresser, HairdresserUpsertRequest, HairdresserUpsertRequest>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public HairdresserRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override IEnumerable<Model.Hairdresser> Get(HairdresserSearchRequest request)
        {
            var query = _context.Hairdressers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.FirstName))
            {
                query = query.Where(x => x.FirstName.Contains(request.FirstName));
            }

            if (!string.IsNullOrWhiteSpace(request?.LastName))
            {
                query = query.Where(x => x.LastName.Contains(request.LastName));
            }

            if (!string.IsNullOrWhiteSpace(request?.Phone))
            {
                query = query.Where(x => x.Phone.Contains(request.Phone));
            }

            if (!string.IsNullOrWhiteSpace(request?.Email))
            {
                query = query.Where(x => x.Email.Contains(request.Email));
            }

            return _mapper.Map<IEnumerable<Model.Hairdresser>>(query.ToList());
        }
    }
}
