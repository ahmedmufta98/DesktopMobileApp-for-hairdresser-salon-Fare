using eHairdresserSalonFare.Api.IRepository;
using eHairdresserSalonFare.Model;
using eHairdresserSalonFare.Model.Requests.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace eHairdresserSalonFare.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository _repository;
        private ILogger _logger;
        public UsersController(IUserRepository repository,
        ILogger<UsersController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        [HttpPost]
        [Route("")]
        [Authorize]
        public IActionResult Insert([FromBody] UserUpsertRequest request)
        {
            try
            {
                return Ok(_repository.Insert(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Post ERROR");
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("")]
        [Authorize]
        public IActionResult Get([FromQuery] UserSearchRequest request)
        {
            try
            {
                return Ok(_repository.Get(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Get ERROR");
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_repository.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetById ERROR");
                return StatusCode(500);
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authorize]
        public IActionResult Update(int id, [FromBody] UserUpsertRequest request)
        {
            try
            {
                return Ok(_repository.Update(id, request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Put ERROR");
                return StatusCode(500);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_repository.Delete(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Delete ERROR");
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserLoginRequest request)
        {
            try
            {
                return Ok(_repository.Login(request));
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Login ERROR");
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromBody] UserUpsertRequest request)
        {
            try
            {
                return Ok(_repository.Register(request));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Register ERROR");
                return StatusCode(500);
            }
        }
    }
}
