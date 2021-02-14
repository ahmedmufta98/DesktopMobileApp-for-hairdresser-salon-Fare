using AutoMapper;
using eHairdresserSalonFare.Api.Database;
using eHairdresserSalonFare.Model.Requests.Payment;
using eHairdresserSalonFareBugojno.DBContext;
using System.Collections.Generic;
using System.Linq;

namespace eHairdresserSalonFare.Api.Repository
{
    public class PaymentRepository : BaseCRUDRepository<Model.Payment, PaymentSearchRequest, Payment, PaymentUpsertRequest, PaymentUpsertRequest>
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public PaymentRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override IEnumerable<Model.Payment> Get(PaymentSearchRequest request)
        {
            var query = _context.Payments.AsQueryable();

            if (request.PaymentDate!=null)
            {
                query = query.Where(x => x.PaymentDate == request.PaymentDate);
            }

            if (request.UserId != null)
            {
                query = query.Where(x => x.UserId == request.UserId);
            }

            return _mapper.Map<IEnumerable<Model.Payment>>(query.ToList());
        }
    }
}
