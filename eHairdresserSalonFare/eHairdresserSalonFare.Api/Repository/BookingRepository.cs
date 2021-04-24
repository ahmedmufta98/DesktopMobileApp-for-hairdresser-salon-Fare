using AutoMapper;
using eHairdresserSalonFare.Model.Requests.Booking;
using eHairdresserSalonFareBugojno.Database;
using eHairdresserSalonFareBugojno.DBContext;
using System.Collections.Generic;
using System.Linq;

namespace eHairdresserSalonFare.Api.Repository
{
    public class BookingRepository : BaseCRUDRepository<Model.Booking, BookingSearchRequest, Booking, BookingUpsertRequest, BookingUpsertRequest>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public BookingRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override IEnumerable<Model.Booking> Get(BookingSearchRequest request)
        {
            var query = _context.Bookings.AsQueryable();

            if (request.HairdresserId!=null)
            {
                query = query.Where(x => x.HairdresserId == request.HairdresserId);
            }

            if (request.HairstyleId != null)
            {
                query = query.Where(x => x.HairstyleId == request.HairstyleId);
            }

            if (request.UserId != null)
            {
                query = query.Where(x => x.UserId == request.UserId);
            }

            if (request.StartDate != null)
            {
                query = query.Where(x => x.StartDate == request.StartDate);
            }

            return _mapper.Map<IEnumerable<Model.Booking>>(query.ToList());
        }

        public override Model.Booking Insert(BookingUpsertRequest model)
        {
            Booking entity = _context.Bookings.FirstOrDefault(b=>b.HairdresserId==model.HairdresserId &&
                             (b.StartDate == model.StartDate) || (b.StartDate < model.StartDate && b.EndDate > model.StartDate) || (b.StartDate < model.EndDate && b.EndDate > model.EndDate));

            if (entity != null)
                return null;

            Booking booking = _mapper.Map<Booking>(model);

            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return _mapper.Map<Model.Booking>(booking);
        }
    }
}
