using System;
using System.Collections.Generic;
using eHairdresserSalonFare.Api.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHairdresserSalonFare.Api.Controllers
{
    [Route("api/hairdressers/{hairdresserId:int}/hairstyles")]
    [ApiController]
    [Authorize]
    public class HairdresserHairstylesController : ControllerBase
    {
        private readonly IHairdresserHairstyleRepository _repository;
        public HairdresserHairstylesController(IHairdresserHairstyleRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Insert(int hairdresserId, List<int> hairstyleIds)
        {
            try
            {
                foreach(var hairstyleId in hairstyleIds)
                {
                    Model.HairdresserHairstyle model = _repository.TryFind(hairdresserId, hairstyleId);
                    if (model != null)
                    {
                        continue;
                    }
                    else
                    {
                        _repository.Insert(hairdresserId, hairstyleId);
                    }
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("")]
        public IActionResult FindHairstylesOfHairdresser(int hairdresserId)
        {
            try
            {
                return Ok(_repository.FindHairstylesOfHairdresser(hairdresserId));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}