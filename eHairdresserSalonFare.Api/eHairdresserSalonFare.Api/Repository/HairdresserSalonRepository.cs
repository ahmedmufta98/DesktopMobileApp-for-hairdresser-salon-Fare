using AutoMapper;
using eHairdresserSalonFare.Model.Requests.HairdresserSalon;
using eHairdresserSalonFareBugojno.Database;
using eHairdresserSalonFareBugojno.DBContext;

namespace eHairdresserSalonFare.Api.Repository
{
    public class HairdresserSalonRepository : BaseCRUDRepository<Model.HairdresserSalon, object, HairdresserSalon, HairdresserSalonUpdateRequest, HairdresserSalonUpdateRequest>
    {
        public HairdresserSalonRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
