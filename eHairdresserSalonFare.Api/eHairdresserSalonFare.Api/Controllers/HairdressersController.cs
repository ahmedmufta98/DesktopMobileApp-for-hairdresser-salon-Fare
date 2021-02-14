using eHairdresserSalonFare.Api.IRepository;
using eHairdresserSalonFare.Model;
using eHairdresserSalonFare.Model.Requests.Hairdresser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eHairdresserSalonFare.Api.Controllers
{
    [Route("api/hairdressers")]
    [ApiController]
    [Authorize]
    public class HairdressersController : BaseCRUDController<Model.Hairdresser, HairdresserSearchRequest, HairdresserUpsertRequest, HairdresserUpsertRequest>
    {
        public HairdressersController(IBaseCRUDRepository<Hairdresser, HairdresserSearchRequest, HairdresserUpsertRequest, HairdresserUpsertRequest> repository, ILogger<BaseCRUDController<Hairdresser, HairdresserSearchRequest, HairdresserUpsertRequest, HairdresserUpsertRequest>> logger) : base(repository, logger)
        {
        }
    }
}
