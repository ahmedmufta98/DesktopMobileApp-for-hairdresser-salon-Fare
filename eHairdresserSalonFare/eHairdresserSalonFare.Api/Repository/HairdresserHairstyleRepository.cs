using AutoMapper;
using eHairdresserSalonFare.Api.IRepository;
using eHairdresserSalonFareBugojno.Database;
using eHairdresserSalonFareBugojno.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace eHairdresserSalonFare.Api.Repository
{
    public class HairdresserHairstyleRepository : IHairdresserHairstyleRepository
    {
        private readonly AppDbContext _context = null;
        private readonly IMapper _mapper = null;

        public HairdresserHairstyleRepository(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public List<Model.Hairdresser> FindHairdressersForRating(int clientId)
        {
            List<Hairdresser> _hairdressersForRating = _context.Hairdressers.Where(h => h.Booking.UserId == clientId).Distinct().ToList();

            if(_hairdressersForRating.Count>0)
                return _mapper.Map<List<Model.Hairdresser>>(_hairdressersForRating);
            else
                return null;
        }

        public List<Model.Hairstyle> FindHairstylesOfHairdresser(int hairdresserId)
        {
            List<Hairstyle> _hairstylesOfHairdresser = _context.Hairstyles.Where(x => x.HairdresserHairstyle.HairdresserId == hairdresserId)
                                                                          .Include(x => x.HairdresserHairstyle).ToList();

            if (_hairstylesOfHairdresser.Count > 0)
                return _mapper.Map<List<Model.Hairstyle>>(_hairstylesOfHairdresser);
            else
                return null;
        }

        public Model.HairdresserHairstyle Insert(int hairdresserId, int hairstyleId)
        {
            HairdresserHairstyle model = new HairdresserHairstyle()
            {
                HairdresserId = hairdresserId,
                HairstyleId = hairstyleId
            };

            _context.HairdresserHairstyles.Add(model);
            _context.SaveChanges();

            return _mapper.Map<Model.HairdresserHairstyle>(model);
        }

        public Model.HairdresserHairstyle TryFind(int hairdresserId, int hairstyleId)
        {
            HairdresserHairstyle hairdresserHairstyle = _context.HairdresserHairstyles.FirstOrDefault(x => x.HairstyleId == hairstyleId && x.HairdresserId == hairdresserId);

            if (hairdresserHairstyle == null)
                return null;
            else
                return _mapper.Map<Model.HairdresserHairstyle>(hairdresserHairstyle);
        }
    }
}
