using AutoMapper;
using eHairdresserSalonFare.Model.Requests.Notification;
using eHairdresserSalonFareBugojno.Database;
using eHairdresserSalonFareBugojno.DBContext;
using System.Collections.Generic;
using System.Linq;

namespace eHairdresserSalonFare.Api.Repository
{
    public class NotificationRepository : BaseCRUDRepository<Model.Notification, NotificationSearchRequest, Notification, NotificationUpsertRequest, NotificationUpsertRequest>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public NotificationRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override IEnumerable<Model.Notification> Get(NotificationSearchRequest request)
        {
            var query = _context.Notifications.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request?.Title))
            {
                query = query.Where(x => x.Title.Contains(request.Title));
            }

            return _mapper.Map<IEnumerable<Model.Notification>>(query.ToList());
        }
    }
}
