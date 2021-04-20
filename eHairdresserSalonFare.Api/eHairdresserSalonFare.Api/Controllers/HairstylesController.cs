using eHairdresserSalonFare.Api.IRepository;
using eHairdresserSalonFare.Model;
using eHairdresserSalonFare.Model.Requests.Hairstyle;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace eHairdresserSalonFare.Api.Controllers
{
    [Route("api/hairstyles")]
    [ApiController]
    [Authorize]
    public class HairstylesController : BaseCRUDController<Model.Hairstyle, HairstyleSearchRequest, HairstyleUpsertRequest, HairstyleUpsertRequest>
    {
        public HairstylesController(IBaseCRUDRepository<Hairstyle, HairstyleSearchRequest, HairstyleUpsertRequest, HairstyleUpsertRequest> repository) : base(repository)
        {
        }
    }
}
