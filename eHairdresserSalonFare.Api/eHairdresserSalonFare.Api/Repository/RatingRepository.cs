using AutoMapper;
using eHairdresserSalonFare.Model.Requests.Rating;
using eHairdresserSalonFareBugojno.Database;
using eHairdresserSalonFareBugojno.DBContext;

namespace eHairdresserSalonFare.Api.Repository
{
    public class RatingRepository : BaseCRUDRepository<Model.Rating, object, Rating, RatingInsertRequest, RatingInsertRequest>
    {
        public RatingRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
