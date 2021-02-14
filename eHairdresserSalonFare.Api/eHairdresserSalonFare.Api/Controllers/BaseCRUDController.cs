using eHairdresserSalonFare.Api.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace eHairdresserSalonFare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseCRUDController<T, TSearch, TInsert, TUpdate> : ControllerBase
    {
        private readonly IBaseCRUDRepository<T, TSearch, TInsert, TUpdate> _repository = null;
        protected ILogger _logger;
        public BaseCRUDController(IBaseCRUDRepository<T, TSearch, TInsert, TUpdate> repository, ILogger<BaseCRUDController<T, TSearch, TInsert, TUpdate>> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpPost]
        [Route("")]
        public IActionResult Insert([FromBody] TInsert request)
        {
            try
            {
                return Ok(_repository.Insert(request));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Post ERROR");
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("")]
        public IActionResult Get([FromQuery] TSearch request)
        {
            try
            {
                return Ok(_repository.Get(request));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Get ERROR");
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_repository.GetById(id));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "GetById ERROR");
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id, [FromBody] TUpdate request)
        {
            try
            {
                return Ok(_repository.Update(id, request));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Put ERROR");
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_repository.Delete(id));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Delete ERROR");
                return StatusCode(500);
            }
        }
    }
}
