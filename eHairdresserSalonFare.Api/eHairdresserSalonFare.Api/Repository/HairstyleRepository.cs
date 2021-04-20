using AutoMapper;
using eHairdresserSalonFare.Model.Requests.Hairstyle;
using eHairdresserSalonFareBugojno.Database;
using eHairdresserSalonFareBugojno.DBContext;
using System.Collections.Generic;
using System.Linq;

namespace eHairdresserSalonFare.Api.Repository
{
    public class HairstyleRepository : BaseCRUDRepository<Model.Hairstyle, HairstyleSearchRequest, Hairstyle, HairstyleUpsertRequest, HairstyleUpsertRequest>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public HairstyleRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override IEnumerable<Model.Hairstyle> Get(HairstyleSearchRequest request)
        {
            var query = _context.Hairstyles.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.HairstyleName))
            {
                query = query.Where(x => x.HairstyleName.Contains(request.HairstyleName));
            }

            return _mapper.Map<IEnumerable<Model.Hairstyle>>(query.ToList());
        }
    }
}
