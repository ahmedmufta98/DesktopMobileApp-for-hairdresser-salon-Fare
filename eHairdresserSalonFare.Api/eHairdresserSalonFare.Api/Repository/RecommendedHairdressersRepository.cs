using AutoMapper;
using eHairdresserSalonFare.Api.IRepository;
using eHairdresserSalonFareBugojno.Database;
using eHairdresserSalonFareBugojno.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eHairdresserSalonFare.Api.Repository
{
    public class RecommendedHairdressersRepository : IRecommendedHairdressersRepository
    {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public RecommendedHairdressersRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        Dictionary<int, List<Rating>> hairdressers = new Dictionary<int, List<Rating>>();

        public List<Model.Hairdresser> RecommendedHairdressers(int hairdresserId)
        {
            var tmp = LoadSimilar(hairdresserId);
            return _mapper.Map<List<Model.Hairdresser>>(tmp);
        }

        private List<Hairdresser> LoadSimilar(int hairdresserId)
        {
            LoadOtherHairdressers(hairdresserId);
            List<Rating> ratingOfCurrent = _context.Ratings.Where(x => x.HairdresserId == hairdresserId).OrderBy(x => x.UserId).ToList();

            List<Rating> ratings1 = new List<Rating>();
            List<Rating> ratings2 = new List<Rating>();
            List<Hairdresser> recommendedHairdressers = new List<Hairdresser>();

            foreach (var hairdresser in hairdressers)
            {
                foreach (Rating rating in ratingOfCurrent)
                {
                    if (hairdresser.Value.Where(w => w.UserId == rating.UserId).Count() > 0)
                    {
                        ratings1.Add(rating);
                        ratings2.Add(hairdresser.Value.Where(w => w.UserId == rating.UserId).First());
                    }
                }
                double similarity = GetSimilarity(ratings1, ratings2);
                if (similarity > 0.5)
                {
                    recommendedHairdressers.Add(_context.Hairdressers.Where(w => w.Id == hairdresser.Key).FirstOrDefault());
                }
                ratings1.Clear();
                ratings2.Clear();
            }
            return recommendedHairdressers;
        }

        private double GetSimilarity(List<Rating> ratings1, List<Rating> ratings2)
        {
            if (ratings1.Count != ratings2.Count)
            {
                return 0;
            }
            double x = 0, y1 = 0, y2 = 0;
            for (int i = 0; i < ratings1.Count; i++)
            {
                x += ratings1[i].Rate * ratings2[i].Rate;
                y1 += ratings1[i].Rate * ratings1[i].Rate;
                y2 += ratings2[i].Rate * ratings2[i].Rate;
            }
            y1 = Math.Sqrt(y1);
            y2 = Math.Sqrt(y2);

            double y = y1 * y2;
            if (y == 0)
                return 0;
            return x / y;
        }

        private void LoadOtherHairdressers(int hairdresserId)
        {
            List<Hairdresser> list = _context.Hairdressers.Where(w => w.Id != hairdresserId).ToList();
            List<Rating> ratings = new List<Rating>();
            foreach (var item in list)
            {
                ratings = _context.Ratings.Where(w => w.HairdresserId == item.Id).OrderBy(w => w.HairdresserId).ToList();
                if (ratings.Count > 0)
                {
                    hairdressers.Add(item.Id, ratings);
                }
            }
        } 
    }
}
