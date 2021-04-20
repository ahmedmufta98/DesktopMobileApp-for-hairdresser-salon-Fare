using eHairdresserSalonFare.Api.IRepository;
using eHairdresserSalonFare.Model;
using eHairdresserSalonFare.Model.Requests.Sponsor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHairdresserSalonFare.Api.Controllers
{
    [Route("api/sponsors")]
    [ApiController]
    [Authorize]
    public class SponsorsController : BaseCRUDController<Model.Sponsor, SponsorSearchRequest, SponsorUpsertRequest, SponsorUpsertRequest>
    {
        public SponsorsController(IBaseCRUDRepository<Sponsor, SponsorSearchRequest, SponsorUpsertRequest, SponsorUpsertRequest> repository) : base(repository)
        {
        }
    }
}