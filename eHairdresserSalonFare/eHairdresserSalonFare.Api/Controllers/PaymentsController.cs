using eHairdresserSalonFare.Api.IRepository;
using eHairdresserSalonFare.Model;
using eHairdresserSalonFare.Model.Requests.Payment;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHairdresserSalonFare.Api.Controllers
{
    [Route("api/payments")]
    [ApiController]
    [Authorize]
    public class PaymentsController : BaseCRUDController<Model.Payment, PaymentSearchRequest, PaymentUpsertRequest, PaymentUpsertRequest>
    {
        public PaymentsController(IBaseCRUDRepository<Payment, PaymentSearchRequest, PaymentUpsertRequest, PaymentUpsertRequest> repository) : base(repository)
        {
        }
    }
}
