using eHairdresserSalonFare.Api.IRepository;
using eHairdresserSalonFare.Model;
using eHairdresserSalonFare.Model.Requests.HairdresserSalon;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eHairdresserSalonFare.Api.Controllers
{
    [Route("api/hairdressersalons")]
    [ApiController]
    [Authorize]
    public class HairdresserSalonsController : BaseCRUDController<Model.HairdresserSalon, object, HairdresserSalonUpdateRequest, HairdresserSalonUpdateRequest>
    {
        public HairdresserSalonsController(IBaseCRUDRepository<HairdresserSalon, object, HairdresserSalonUpdateRequest, HairdresserSalonUpdateRequest> repository) : base(repository)
        {
        }
    }
}