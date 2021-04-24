using eHairdresserSalonFare.Api.IRepository;
using eHairdresserSalonFare.Model;
using eHairdresserSalonFare.Model.Requests.Notification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eHairdresserSalonFare.Api.Controllers
{
    [Route("api/notifications")]
    [ApiController]
    [Authorize]
    public class NotificationsController : BaseCRUDController<Model.Notification, NotificationSearchRequest, NotificationUpsertRequest, NotificationUpsertRequest>
    {
        public NotificationsController(IBaseCRUDRepository<Notification, NotificationSearchRequest, NotificationUpsertRequest, NotificationUpsertRequest> repository) : base(repository)
        {
        }
    }

}