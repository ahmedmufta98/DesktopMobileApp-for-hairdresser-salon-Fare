using eHairdresserSalonFare.Api.IRepository;
using eHairdresserSalonFare.Model.Requests.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace eHairdresserSalonFare.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository _repository;
        public UsersController(IUserRepository repository)
        {
            _repository = repository;
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
                return StatusCode(500, ex);
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
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("{userId:int}/payments")]
        [Authorize]
        public IActionResult GetPaymentsOfUser(int userId)
        {
            try
            {
                return Ok(_repository.GetPaymentsOfUser(userId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
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
                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("username")]
        public IActionResult GetByUsername([FromQuery] UserLoginRequest request)
        {
            try
            {
                return Ok(_repository.GetByUsername(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
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
                return StatusCode(500, ex);
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
                return StatusCode(500, ex);
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
                return StatusCode(500, ex);
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
                return StatusCode(500, ex);
            }
        }
    }
}
