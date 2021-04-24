using eHairdresserSalonFare.Api.IRepository;
using eHairdresserSalonFare.Model;
using eHairdresserSalonFare.Model.Requests.Rating;
using Microsoft.AspNetCore.Mvc;

namespace eHairdresserSalonFare.Api.Controllers
{
    [Route("api/ratings")]
    [ApiController]
    public class RatingsController : BaseCRUDController<Model.Rating, object, RatingInsertRequest, RatingInsertRequest>
    {
        public RatingsController(IBaseCRUDRepository<Rating, object, RatingInsertRequest, RatingInsertRequest> repository) : base(repository)
        {
        }
    }
}