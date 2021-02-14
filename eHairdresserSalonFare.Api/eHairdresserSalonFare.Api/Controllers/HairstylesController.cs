using eHairdresserSalonFare.Api.IRepository;
using eHairdresserSalonFare.Model;
using eHairdresserSalonFare.Model.Requests.Hairstyle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace eHairdresserSalonFare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HairstylesController : BaseCRUDController<Model.Hairstyle, HairstyleSearchRequest, HairstyleUpsertRequest, HairstyleUpsertRequest>
    {
        public HairstylesController(IBaseCRUDRepository<Hairstyle, HairstyleSearchRequest, HairstyleUpsertRequest, HairstyleUpsertRequest> repository, ILogger<BaseCRUDController<Hairstyle, HairstyleSearchRequest, HairstyleUpsertRequest, HairstyleUpsertRequest>> logger) : base(repository, logger)
        {
        }
    }
}
