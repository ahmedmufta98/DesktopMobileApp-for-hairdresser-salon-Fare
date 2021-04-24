using eHairdresserSalonFare.Api.IRepository;
using eHairdresserSalonFare.Model;
using eHairdresserSalonFare.Model.Requests.Hairdresser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace eHairdresserSalonFare.Api.Controllers
{
    [Route("api/hairdressers")]
    [ApiController]
    [Authorize]
    public class HairdressersController : BaseCRUDController<Model.Hairdresser, HairdresserSearchRequest, HairdresserUpsertRequest, HairdresserUpsertRequest>
    {
        private readonly IHairdresserHairstyleRepository _hairdresserHairstyleRepository;
        public HairdressersController(IBaseCRUDRepository<Hairdresser, HairdresserSearchRequest, HairdresserUpsertRequest, HairdresserUpsertRequest> repository,
            IHairdresserHairstyleRepository hairdresserHairstyleRepository) : base(repository)
        {
            _hairdresserHairstyleRepository = hairdresserHairstyleRepository;
        }

        [HttpGet]
        [Route("{clientId:int}/ratinghairdressers")]
        public IActionResult FindHairdressersOfClientForRating(int clientId)
        {
            try
            {
                return Ok(_hairdresserHairstyleRepository.FindHairdressersForRating(clientId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
