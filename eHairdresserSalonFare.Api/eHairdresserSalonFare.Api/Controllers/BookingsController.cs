using eHairdresserSalonFare.Api.IRepository;
using eHairdresserSalonFare.Model;
using eHairdresserSalonFare.Model.Requests.Booking;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHairdresserSalonFare.Api.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    [Authorize]
    public class BookingsController : BaseCRUDController<Model.Booking, BookingSearchRequest, BookingUpsertRequest, BookingUpsertRequest>
    {
        public BookingsController(IBaseCRUDRepository<Booking, BookingSearchRequest, BookingUpsertRequest, BookingUpsertRequest> repository) : base(repository)
        {
        }
    }
}