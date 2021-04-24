using eHairdresserSalonFare.Api.IRepository;
using eHairdresserSalonFare.Model;
using eHairdresserSalonFare.Model.Requests.Associate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHairdresserSalonFare.Api.Controllers
{
    [Route("api/associates")]
    [ApiController]
    [Authorize]
    public class AssociatesController : BaseCRUDController<Model.Associate, AssociateSearchRequest, AssociateUpsertRequest, AssociateUpsertRequest>
    {
        public AssociatesController(IBaseCRUDRepository<Associate, AssociateSearchRequest, AssociateUpsertRequest, AssociateUpsertRequest> repository) : base(repository)
        {
        }
    }
}