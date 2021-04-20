using System;
using eHairdresserSalonFare.Api.IRepository;
using eHairdresserSalonFare.Model.Requests.Hairdresser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHairdresserSalonFare.Api.Controllers
{
    [Route("api/recommendations")]
    [ApiController]
    [Authorize]
    public class RecommendationsController : ControllerBase
    {
        private readonly IRecommendedHairdressersRepository _repository;
        public RecommendationsController(IRecommendedHairdressersRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("")]
        public IActionResult RecommendHairdressers([FromQuery] RecommendedHairdresserSearchRequest request)
        {
            try
            {
                return Ok(_repository.RecommendedHairdressers(request.HairdresserId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}